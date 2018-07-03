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
    [RoutePrefix("api/analytics")]
    public class AnalyticsController : ApiController
    {
        [Route("getPaginas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage GetPagina()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario.ToString());

                    DataTable paginas = sql.ExecuteProcedureDataTable("sp_sel_acessoPagina", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, paginas);
                }               
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("paginainicial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage PaginaInicial()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario.ToString());

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_paginainicial", parametros);
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