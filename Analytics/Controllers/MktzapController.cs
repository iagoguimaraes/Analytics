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
    [RoutePrefix("api/mktzap")]
    public class MktzapController : ApiController
    {
        [Route("dashboard")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard(FormDataCollection form)
        {
            try
            {
                string fDtini = form["fDtini"];
                string fDtfim = form["fDtfim"];
                string eDtini = form["eDtini"];
                string eDtfim = form["eDtfim"];
                string campanhas = form["campanhas"];
                string setores = form["setores"];

                DateTime minDate = Convert.ToDateTime("1753-01-01 12:00:00");
                DateTime maxDate = Convert.ToDateTime("9999-12-31 23:59:59");

                DateTime _fDtini = string.IsNullOrEmpty(fDtini) ? minDate : Convert.ToDateTime(fDtini);
                DateTime _fDtfim = string.IsNullOrEmpty(fDtfim) ? maxDate : Convert.ToDateTime(fDtfim);
                DateTime _eDtini = string.IsNullOrEmpty(eDtini) ? minDate : Convert.ToDateTime(eDtini);
                DateTime _eDtfim = string.IsNullOrEmpty(eDtfim) ? maxDate : Convert.ToDateTime(eDtfim);

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("fDtini", _fDtini);
                    parametros.Add("fDtfim", _fDtfim);
                    parametros.Add("eDtini", _eDtini);
                    parametros.Add("eDtfim", _eDtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);

                    DataSet resultado = sql.ExecuteProcedureDataSet("dashboard_mktzap", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Filtros(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("dashboard_mktzapFiltros");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("negociador")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Negociador(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", _campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("dashboard_negociador", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("gerencial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Gerencial(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];
                string setores = form["setores"];

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);
                DataTable canal = JsonConvert.DeserializeObject<DataTable>(form["canal"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);
                    parametros.Add("canal", canal);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_gerencial", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("operacional")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Operacional(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];
                string setores = form["setores"];

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);
                DataTable canal = JsonConvert.DeserializeObject<DataTable>(form["canal"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);
                    parametros.Add("canal", canal);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_operacional", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage HoraHora(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];
                string setores = form["setores"];

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);
                DataTable canal = JsonConvert.DeserializeObject<DataTable>(form["canal"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);
                    parametros.Add("canal", canal);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Producao(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];
                string setores = form["setores"];

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);
                DataTable canal = JsonConvert.DeserializeObject<DataTable>(form["canal"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);
                    parametros.Add("canal", canal);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Pagamento(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];

                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
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
