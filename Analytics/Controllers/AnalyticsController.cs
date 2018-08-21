using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Analytics.Controllers
{
    [RoutePrefix("api/analytics")]
    public class AnalyticsController : ApiController
    {
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

        [Route("carregarMenu")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CarregarMenu()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario.ToString());

                    DataSet menu = sql.ExecuteProcedureDataSet("sp_sel_carregarMenu", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, menu);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("requisicoes")]
        [HttpPost]
        [Autorizar]
        public async Task<HttpResponseMessage> Requisicoes()
        {
            try
            {
                string WorkspaceId = "544d9d10-0068-480c-a7f6-6bf26c2c6279";
                string ReportId = "0baf7dd7-17fb-4545-8b8c-95c0580a7e70";

                PowerBI powerbi = new PowerBI();
                EmbedConfig dashboard = await powerbi.CarregarDashboard(WorkspaceId, ReportId);
                return Request.CreateResponse(HttpStatusCode.OK, dashboard);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}