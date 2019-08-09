using Analytics.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Analytics.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {
        private void ValidarArquivoImportado(string nomearquivo)
        {
            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@nomearquivo", nomearquivo);

                DataTable dt = sql.ExecuteQueryDataTable(@"
                        select nomearquivo, convert(varchar(16),data_upload,121) data from TB_LOTE where nomearquivo = @nomearquivo"
                , parametros);

                if (dt.Rows.Count > 0)
                {
                    throw new Exception(string.Format("O Arquivo: {0} já existe e foi importado as {1}", nomearquivo, dt.Rows[0][1]));
                }
            }
        }

        [Route("lote/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LoteFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_filtros");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("lote/getCarteiraLayout")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LotegetCarteiraLayout(FormDataCollection form)
        {
            try
            {
                int carteira = Convert.ToInt16(form["carteira"]);

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("idcarteira", carteira);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_sel_carteira_layout", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("lote/getPreviewLayout")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LotegetPreviewLayout(FormDataCollection form)
        {

            int idlayout = Convert.ToInt16(form["layout"]);

            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("idlayout", idlayout);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_getLayout", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("lote/upload")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LoteUpload(FormDataCollection form)
        {
            try
            {
                int idcentrocusto = Convert.ToInt16(form["centrocusto"]);
                int idcarteira = Convert.ToInt16(form["carteira"]);
                int idfornecedor = Convert.ToInt16(form["fornecedor"]);
                int idlayout = Convert.ToInt16(form["layout"]);
                var tabela = form["tabela"];
                string blob = form["arquivo"];
                string nomearquivo = form["nomearquivo"];

                byte[] data = Convert.FromBase64String(blob.Substring(blob.IndexOf(",") + 1));
                string arquivo = Encoding.UTF8.GetString(data);

                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("idcentrocusto", idcentrocusto);
                    parametros.Add("idcarteira", idcarteira);
                    parametros.Add("idfornecedor", idfornecedor);
                    parametros.Add("idlayout", idlayout);
                    parametros.Add("idusuario", Convert.ToInt16(sessao.id_usuario.ToString()));
                    parametros.Add("dtupload", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("nomearquivo", nomearquivo);

                    ValidarArquivoImportado(nomearquivo);

                    //retorna do id_lote
                    int idlote = sql.ExecuteProcedureInt("sp_ins_lote", parametros);


                    //verifica o id_layout                    
                    if (idlayout == 1)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout simples
                        DataTable dt = new CsvHelper().CarregarArquivoSimples(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_SIMPLES
                        sql.BulkInsert(tabela, dt);

                    }
                    else if (idlayout == 2)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout CLARO TV
                        DataTable dt = new CsvHelper().CarregarArquivoClaroTv(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_CLARO_TV
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamClaroTv = new Dictionary<String, Object>();
                        ParamClaroTv.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_claro_tv", ParamClaroTv);

                    }
                    else if (idlayout == 3)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout CLARO MOVEL
                        DataTable dt = new CsvHelper().CarregarArquivoClaroMovel(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_CLARO_MOVEL
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamClaroMovel = new Dictionary<String, Object>();
                        ParamClaroMovel.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_claro_movel", ParamClaroMovel);
                    }
                    else if (idlayout == 4)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout NET
                        DataTable dt = new CsvHelper().CarregarArquivoNet(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_NET
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamNet = new Dictionary<String, Object>();
                        ParamNet.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_net", ParamNet);
                    }
                    else if (idlayout == 5)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout CLARO TV CANCELADO
                        DataTable dt = new CsvHelper().CarregarArquivoClaroTvCancelado(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_CLARO_TV_CANCELADO
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamClaroTvCancelado = new Dictionary<String, Object>();
                        ParamClaroTvCancelado.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_claro_tv_cancelado", ParamClaroTvCancelado);
                    }
                    else if (idlayout == 6)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout CLARO MOVEL CANCELADO
                        DataTable dt = new CsvHelper().CarregarArquivoClaroMovelCancelado(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_CLARO_MOVEL_CANCELADO
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamClaroMovelCancelado = new Dictionary<String, Object>();
                        ParamClaroMovelCancelado.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_claro_movel_cancelado", ParamClaroMovelCancelado);
                    }
                    else if (idlayout == 7)
                    {
                        //Monta o datatable com os registros do arquivo.csv layout NET CANCELADO
                        DataTable dt = new CsvHelper().CarregarArquivoNetCancelado(arquivo, idlote);

                        //Insere os registros do datatable na TB_LAYOUT_NET_CANCELADO
                        sql.BulkInsert(tabela.Replace("TB", "STAGE"), dt);

                        Dictionary<string, object> ParamNetCancelado = new Dictionary<String, Object>();
                        ParamNetCancelado.Add("idlote", idlote);

                        sql.ExecuteProcedure("sp_ins_layout_net_cancelado", ParamNetCancelado);
                    }

                    // Chama o Método da API para envio do lote SMS;
                    using (TalkIP api = new TalkIP())
                    {
                        try
                        {
                            api.EnviarLoteSMS(idlote, idlayout);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }

                    }

                    return Request.CreateResponse(HttpStatusCode.OK, idlote);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("talkip")]
        [HttpGet]
        public HttpResponseMessage TalkIP()
        {
            try
            {
                // VALIDAR
                //string path = @"\\luxemburgo\public\talkipdebug.txt";
                //File.AppendAllLines(path, new string[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Request.RequestUri.Query });

                long id_registro = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("idregistro"));
                int id_layout = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("idlayout"));
                int id_lote = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("idlote"));
                int codigo_status = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("status"));
                int id_unico_fornecedor = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("id"));

                using (TalkIP api = new TalkIP())
                {
                    api.AtualizarStatus(id_registro, id_layout, codigo_status, id_lote, id_unico_fornecedor);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/acompanhamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAcompanhamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable centrocusto = JsonConvert.DeserializeObject<DataTable>(form["centrocusto"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable fornecedores = JsonConvert.DeserializeObject<DataTable>(form["fornecedores"]);

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("centrocusto", centrocusto);
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acompanhamento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/custo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardCusto(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable centrocusto = JsonConvert.DeserializeObject<DataTable>(form["centrocusto"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable fornecedores = JsonConvert.DeserializeObject<DataTable>(form["fornecedores"]);
                DataTable estados = JsonConvert.DeserializeObject<DataTable>(form["estados"]);

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("centrocusto", centrocusto);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("fornecedores", fornecedores);
                    parametros.Add("estados", estados);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_custo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
