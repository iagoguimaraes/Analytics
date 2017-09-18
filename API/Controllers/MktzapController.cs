using BLL;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        public HttpResponseMessage Dashboard(FormDataCollection form)
        {
            try
            {
                bMktzap blo = new bMktzap();
                return Request.CreateResponse(HttpStatusCode.OK, blo.Dashboard());
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
