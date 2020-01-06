using Analytics.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/cpfl")]


    public class CpflController : ApiController
    {
        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltrosHumano()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);

                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/lote")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardLote(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                //int situacao = Convert.ToInt32(form["situacao"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    //parametros.Add("situacao", situacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_lote", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/acionamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Acionamento(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkCarteira = form["chkCarteira"];
                string chkAging = form["chkAging"];
                string chkFaixaValor = form["chkFaixaValor"];

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    
                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    
                    parametros.Add("chkCarteira", chkCarteira);
                    parametros.Add("chkAging", chkAging);
                    parametros.Add("chkFaixaValor", chkFaixaValor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acionamento", parametros);

                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }


        }

        [Route("dashboard/download")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadExcel(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkCarteira = form["chkCarteira"];
                string chkAging = form["chkAging"];
                string chkFaixaValor = form["chkFaixaValor"];

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);

                    parametros.Add("chkCarteira", chkCarteira);
                    parametros.Add("chkAging", chkAging);
                    parametros.Add("chkFaixaValor", chkFaixaValor);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_CPFL_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        [Route("dashboard/recebimento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRecebimento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_recebimento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/projecao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProjecao()
        {
            try
            {

                using (SqlHelper sql = new SqlHelper("CUBO_CPFL"))
                {

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_projecao");
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
