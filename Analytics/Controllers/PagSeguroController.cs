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
    [RoutePrefix("api/pagseguro")]
    public class PagSeguroController : ApiController
    {

        [Route("dashboard/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                int hrini = Convert.ToInt32(form["hrini"]);
                int hrfim = Convert.ToInt32(form["hrfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_PAGSEGURO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("hrini", hrini);
                    parametros.Add("hrfim", hrfim);

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
        public HttpResponseMessage DashboardProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_PAGSEGURO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_PAGSEGURO"))
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

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkCarteira = form["chkCarteira"];

                using (SqlHelper sql = new SqlHelper("CUBO_PAGSEGURO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    parametros.Add("chkCarteira", chkCarteira);

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

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkCarteira = form["chkCarteira"];

                using (SqlHelper sql = new SqlHelper("CUBO_PAGSEGURO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);

                    parametros.Add("chkCarteira", chkCarteira);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_PAGSEGURO_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}