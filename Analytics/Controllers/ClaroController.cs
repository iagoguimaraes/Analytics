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
    [RoutePrefix("api/claro")]
    public class ClaroController : ApiController
    {

        #region DIGITAL

        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
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

        [Route("dashboard/digital/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("origem", origem);
                    parametros.Add("campanhas", campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("origem", origem);
                    parametros.Add("campanhas", campanhas);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/btc")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBTC(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanha", campanha);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_btc_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagamentos(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("origem", origem);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion


        #region HUMANO

        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltrosHumano()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros_humano");
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
        public HttpResponseMessage DashboardHoraHoraHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);


                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("equipe", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_humano", parametros);
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
        public HttpResponseMessage DashboardProducaoHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_CLARO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("equipe", equipes);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_humano", parametros);
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
