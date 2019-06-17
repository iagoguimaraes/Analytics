using Analytics.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {
        [Route("lote/upload")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage LoteUpload()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upload");
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
