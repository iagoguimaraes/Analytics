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
    [RoutePrefix("api/pagina")]
    public class PaginaController : ApiController
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
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_paginas");
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
                int id_pagina = Convert.ToInt32(form["id_pagina"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_pagina", parametros);
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
                string nome = form["nome"];
                string url = form["url"];
                string icone = form["icone"];
                int ordem = Convert.ToInt32(form["posicao"]);
                int id_credor = Convert.ToInt32(form["indicador"]);



                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // INSERIR GRUPO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("path", path);
                    parametros.Add("nome", nome);
                    parametros.Add("url", url);
                    parametros.Add("icone", icone);
                    parametros.Add("ordem", ordem);
                    parametros.Add("id_credor", id_credor);
                

                    DataTable result = sql.ExecuteProcedureDataTable("sp_ins_pagina", parametros);

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

                int id_pagina = Convert.ToInt32(form["id_pagina"]);
                string path = form["path"];
                string nome = form["nome"];
                string url = form["url"];
                string icone = form["icone"];
                int ordem = Convert.ToInt32(form["ordem"]);
                int id_credor = Convert.ToInt32(form["id_credor"]);
                bool ativo = Convert.ToBoolean(form["ativo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    // ALTERAR O USUARIO
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);
                    parametros.Add("path", path);
                    parametros.Add("nome", nome);
                    parametros.Add("url", url);
                    parametros.Add("icone", icone);
                    parametros.Add("ordem", ordem);
                    parametros.Add("id_credor", id_credor);
                    parametros.Add("ativo", ativo ? 1 : 0);
                    sql.ExecuteProcedure("sp_upd_pagina", parametros);


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
