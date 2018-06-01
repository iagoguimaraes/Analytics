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
    [RoutePrefix("api/kroton")]
    public class KrotonController : ApiController
    {

        [Route("dashboard/filtros")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros(FormDataCollection form)
        {
            try
            {
                int id_empresa = Convert.ToInt16(form["id_empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_KROTON"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();                    

                    parametros.Add("empresa", id_empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros", parametros);
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
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable statusAluno = JsonConvert.DeserializeObject<DataTable>(form["statusAluno"]);
                int id_empresa = Convert.ToInt16(form["id_empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_KROTON"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("statusAluno", statusAluno);
                    parametros.Add("empresa", id_empresa);

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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable statusAluno = JsonConvert.DeserializeObject<DataTable>(form["statusAluno"]);
                int id_empresa = Convert.ToInt16(form["id_empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_KROTON"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("statusAluno", statusAluno);
                    parametros.Add("empresa", id_empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/multicanal")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage MultiCanalidade(FormDataCollection form)
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

                using (SqlHelper sql = new SqlHelper("CUBO_KROTON"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("fDtini", _fDtini);
                    parametros.Add("fDtfim", _fDtfim);
                    parametros.Add("eDtini", _eDtini);
                    parametros.Add("eDtfim", _eDtfim);
                    parametros.Add("campanhas", _campanhas);
                    parametros.Add("setores", _setores);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_mktzap", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/multicanalFiltro")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Filtros(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_KROTON"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_mktzapFiltros");
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
