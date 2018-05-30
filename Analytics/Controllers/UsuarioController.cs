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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
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
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_usuarios");
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
                int id_usuario = Convert.ToInt32(form["id_usuario"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_usuario", id_usuario);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_usuario", parametros);
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
                string login = form["login"];
                bool cliente = Convert.ToBoolean(form["cliente"]);
                DataTable grupos = JsonConvert.DeserializeObject<DataTable>(form["grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // INSERIR USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("nome", nome);
                    parametros.Add("login", login);
                    parametros.Add("cliente", cliente ? 1 : 0);
                    DataTable result = sql.ExecuteProcedureDataTable("sp_ins_usuario", parametros);
                    string id_usuario = result.Rows[0]["id_usuario"].ToString();

                    // INSERIR OS GRUPOS
                    Dictionary<string, object> parametros2 = new Dictionary<string, object>();
                    parametros2.Add("id_usuario", id_usuario);
                    parametros2.Add("id_grupo", grupos);

                    sql.ExecuteProcedure("sp_ins_grupoUsuario", parametros2);

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
                int id_usuario = Convert.ToInt32(form["id_usuario"]);
                string nome = form["nome"];
                string login = form["login"];
                bool cliente = Convert.ToBoolean(form["cliente"]);
                bool ativo = Convert.ToBoolean(form["ativo"]);
                DataTable grupos = JsonConvert.DeserializeObject<DataTable>(form["grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // ALTERAR O USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_usuario", id_usuario);
                    parametros.Add("nome", nome);
                    parametros.Add("login", login);
                    parametros.Add("cliente", cliente ? 1 : 0);
                    parametros.Add("ativo", ativo ? 1 : 0);
                    sql.ExecuteProcedure("sp_upd_usuario", parametros);

                    // ALTERAR OS GRUPOS
                    Dictionary<string, object> parametros2 = new Dictionary<string, object>();
                    parametros2.Add("id_usuario", id_usuario);
                    parametros2.Add("id_grupo", grupos);
                    sql.ExecuteProcedure("sp_ins_grupoUsuario", parametros2);

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
