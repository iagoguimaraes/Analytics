using Analytics.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Analytics.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {

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

        [Route("lote/getPreviewLayout")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LotegetPreviewLayout(FormDataCollection form)
        {

            var tabela = form["tabela"];

            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("tabela", tabela.ToString());

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_getPreviewLayout", parametros);
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

                    int resultado = sql.ExecuteProcedureInt("sp_upload", parametros);

                    string[] str = new string[] { "\r\n" };
                    string[] linhas = arquivo.Split(str, StringSplitOptions.None);
                    string[] cabecalho = linhas[0].Split(';');                    

                    DataTable dt = new DataTable();

                    //for (int i = 0; i < cabecalho.Length; i++)                        
                    //dt.Columns.Add(cabecalho[i]);

                    dt.Columns.Add("telefone");
                    dt.Columns.Add("mensagem");
                    dt.Columns.Add("cpf");
                    dt.Columns.Add("id_lote", typeof(int)).DefaultValue = resultado;

                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dt.NewRow();                      

                        row.ItemArray = linhas[i].Split(';');

                        dt.Rows.Add(row);
                    }


                    sql.BulkInsert(tabela, dt);

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
