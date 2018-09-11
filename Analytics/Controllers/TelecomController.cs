using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/telecom")]
    public class TelecomController : ApiController
    {
        [Route("horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage PaginaInicial()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora");
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
