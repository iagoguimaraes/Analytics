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
    [RoutePrefix("api/recurso")]
    public class RecursoController : ApiController
    {
        [Route("obter")]
        [HttpGet]
        [Autorizar]
        public HttpResponseMessage Obter()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_recursos");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("consultar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage Consultar(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_recurso", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("inserir")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage Inserir(FormDataCollection form)
        {
            try
            {
                string path = form["path"];
                string dashboard = form["dashboard"];
                string pagina = form["pagina"];

                if (dashboard == null && pagina == null)
                {
                    dashboard = "";
                    pagina = "";

                }

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // INSERIR GRUPO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();



                    parametros.Add("path", path);
                    parametros.Add("dashboard", dashboard);
                    parametros.Add("pagina", pagina);

                    DataTable result = sql.ExecuteProcedureDataTable("sp_ins_recurso", parametros);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("alterar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage Alterar(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);
                string path = form["path"];
                string dashboard = form["dashboard"];
                string pagina = form["pagina"];

                if (dashboard == null && pagina == null)
                {
                    dashboard = "";
                    pagina = "";

                }

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // ALTERAR O USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);
                    parametros.Add("path", path);
                    parametros.Add("dashboard", dashboard);
                    parametros.Add("pagina", pagina);

                    sql.ExecuteProcedure("sp_upd_recurso", parametros);


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
