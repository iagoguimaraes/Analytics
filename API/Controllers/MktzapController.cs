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
    [RoutePrefix("api/mktzap")]
    public class MktzapController : ApiController
    {
        [Route("dashboard")]
        [HttpPost]
        [Autenticar]
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

                DataSet resultado = new bMktzap().Dashboard(fDtini, fDtfim, eDtini, eDtfim, campanhas, setores);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("filtros")]
        [HttpGet]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage Filtros(FormDataCollection form)
        {
            try
            {
                DataSet resultado = new bMktzap().Filtros();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

       
    }
}
