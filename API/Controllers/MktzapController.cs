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
    [RoutePrefix("api/mktzap")]
    public class MktzapController : ApiController
    {
        [Route("dashboard")]
        [HttpPost]
        public HttpResponseMessage Dashboard(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable setores = JsonConvert.DeserializeObject<DataTable>(form["setores"]);

                DataSet resultado = new bMktzap().Dashboard(dtini, dtfim, campanhas, setores);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("filtros")]
        [HttpGet]
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
