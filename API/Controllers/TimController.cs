using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/tim")]
    public class TimController : ApiController
    {
        [Route("cubo")]
        [HttpPost]
        [Authorization]
        [GravarRequisicao]
        public HttpResponseMessage Cubo(FormDataCollection form)
        {
            try
            {
                DataSet resultado = new bTim().Cubo();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/filtros")]
        [HttpGet]
        [Authorization]
        [GravarRequisicao]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                DataSet resultado = new bTim().DashboardFiltros();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/horahora")]
        [HttpPost]
        [Authorization]
        [GravarRequisicao]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                DataSet resultado = new bTim().DashboardHoraHora(dtini,dtfim, campanhas);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }





    }
}
