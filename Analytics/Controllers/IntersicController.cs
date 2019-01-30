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
    [RoutePrefix("api/intersic")]
    public class IntersicController : ApiController
    {

        [Route("empresa")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_INTERSIC"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_empresa");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("importjob")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage InserirMonitoria(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_job = Convert.ToInt32(form["job"]);
                int id_empresa = Convert.ToInt32(form["empresa"]);


                using (SqlHelper sql = new SqlHelper("DB_INTERSIC"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresa", id_empresa);
                    parametros.Add("idjob", id_job);
                    parametros.Add("id_usuario", sessao.id_usuario);


                    sql.ExecuteProcedureDataSet("sp_ins_job_claro", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
