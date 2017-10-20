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
    [RoutePrefix("api/tim")]
    public class TimController : ApiController
    {
        [Route("cubo")]
        [HttpPost]
        [Authorization]
        [GravarRequisicao]
        public HttpResponseMessage Dashboard(FormDataCollection form)
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
    }
}
