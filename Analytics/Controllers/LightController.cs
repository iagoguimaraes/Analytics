using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/light")]
    public class LightController : ApiController
    {
        #region HUMANO


        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
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

        [Route("dashboard/humano/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixas", faixas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixas", faixas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseAtiva(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);


                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", dtini.ToString("yyyy-MM-dd"));


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_basecobranca", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/efetividade")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEfetividade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/comparativo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComparativo(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int ano2 = Convert.ToInt32(form["ano2"]);
                int mes2 = Convert.ToInt32(form["mes2"]);
                int ano3 = Convert.ToInt32(form["ano3"]);
                int mes3 = Convert.ToInt32(form["mes3"]);

                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("ano2", ano2);
                    parametros.Add("mes2", mes2);
                    parametros.Add("ano3", ano3);
                    parametros.Add("mes3", mes3);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_comparativo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/comparativoproducao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComparativoProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DateTime dtini_2 = Convert.ToDateTime(form["dtini_2"]);
                DateTime dtfim_2 = Convert.ToDateTime(form["dtfim_2"]);

                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);

                int horaini_2 = Convert.ToInt16(form["horaini_2"]);
                int horafim_2 = Convert.ToInt16(form["horafim_2"]);


                string procedure = "sp_dashboard_comparativo_hora";

                if (form["visao"] == "hora")
                    procedure = "sp_dashboard_comparativo_hora";
                if (form["visao"] == "dia")
                    procedure = "sp_dashboard_comparativo_dia";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_dashboard_comparativo_dia_semana";
                if (form["visao"] == "semana")
                    procedure = "sp_dashboard_comparativo_semana";
                if (form["visao"] == "mes")
                    procedure = "sp_dashboard_comparativo_mes";

                using (SqlHelper sql = new SqlHelper("CUBO_LIGHT"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_2", dtini_2.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_2", dtfim_2.ToString("yyyy-MM-dd"));

                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    parametros.Add("horaini_2", horaini_2);
                    parametros.Add("horafim_2", horafim_2);


                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

    }
}
