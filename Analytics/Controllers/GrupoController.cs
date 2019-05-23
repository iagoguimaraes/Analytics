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
    [RoutePrefix("api/grupo")]
    public class GrupoController : ApiController
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
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_grupos");
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
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_grupo", id_grupo);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_grupo", parametros);
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
                string nome = form["nome"];


                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // INSERIR GRUPO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("nome", nome);
                    DataTable result = sql.ExecuteProcedureDataTable("sp_ins_grupo", parametros);

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
                int id_grupo = Convert.ToInt32(form["id_grupo"]);
                string nome = form["nome"];
                bool ativo = Convert.ToBoolean(form["ativo"]);
  
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // ALTERAR O USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_grupo", id_grupo);
                    parametros.Add("nome", nome);
                    parametros.Add("ativo", ativo ? 1 : 0);
                    sql.ExecuteProcedure("sp_upd_grupo", parametros);


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
