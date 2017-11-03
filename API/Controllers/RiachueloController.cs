using BLL;
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
    [RoutePrefix("api/riachuelo")]
    public class RiachueloController : ApiController
    {
        [Route("dashboard/horahora")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string carteiras = form["carteiras"];

                DataSet resultado = new bRiachuelo().DashboardHoraHora(dtini, dtfim, carteiras);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/filtros")]
        [HttpGet]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                DataSet resultado = new bRiachuelo().DashboardFiltros();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/btc")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBTC(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string carteiras = form["carteiras"];

                DataSet resultado = new bRiachuelo().DashboardBTC(dtini, dtfim, carteiras);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
