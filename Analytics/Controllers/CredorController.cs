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
    [RoutePrefix("api/credor")]
    public class CredorController : ApiController
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
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_credores");
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
                int id_credor = Convert.ToInt32(form["id_credor"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_credor", id_credor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_credor", parametros);
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
                string logo = form["logo"];
                string cor_primaria = form["cor_primaria"];
                string cor_secundaria = form["cor_secundaria"];
                string cor_fonte_primaria = form["cor_fonte_primaria"];
                string cor_fonte_secundaria = form["cor_fonte_secundaria"];
                string background = form["background"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // INSERIR GRUPO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("nome", nome);
                    parametros.Add("logo", logo);
                    parametros.Add("cor_primaria", cor_primaria);
                    parametros.Add("cor_secundaria", cor_secundaria);
                    parametros.Add("cor_fonte_primaria", cor_fonte_primaria);
                    parametros.Add("cor_fonte_secundaria", cor_fonte_secundaria);
                    parametros.Add("background", background);

                    DataTable result = sql.ExecuteProcedureDataTable("sp_ins_credor", parametros);

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
                int id_credor = Convert.ToInt32(form["id_credor"]);
                string nome = form["nome"];
                string logo = form["logo"];
                string cor_primaria = form["cor_primaria"];
                string cor_secundaria = form["cor_secundaria"];
                string cor_fonte_primaria = form["cor_fonte_primaria"];
                string cor_fonte_secundaria = form["cor_fonte_secundaria"];
                string background = form["background"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // ALTERAR O USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_credor", id_credor);
                    parametros.Add("logo", logo);
                    parametros.Add("cor_primaria", cor_primaria);
                    parametros.Add("cor_secundaria", cor_secundaria);
                    parametros.Add("cor_fonte_primaria", cor_fonte_primaria);
                    parametros.Add("cor_fonte_secundaria", cor_fonte_secundaria);
                    parametros.Add("background", background);

                    sql.ExecuteProcedure("sp_upd_credor", parametros);


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
