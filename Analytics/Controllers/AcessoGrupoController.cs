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
    [RoutePrefix("api/acessogrupo")]
    public class AcessoGrupoController : ApiController
    {

        [Route("grupo/consultar")]
        [HttpGet]
        [Autorizar]
        public HttpResponseMessage ConsultarGrupo()
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

        [Route("acesso/consultar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage ConsultarAcesso(FormDataCollection form)
        {
            try
            {
                int id_grupo = Convert.ToInt32(form["grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_grupo", id_grupo);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_acesso", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/pagina/inserir")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage InserirAcessoPagina(FormDataCollection form)
        {
            try
            {
                int id_pagina = Convert.ToInt32(form["id_pagina"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_ins_acessoPagina", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/pagina/remover")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage RemoverAcessoPagina(FormDataCollection form)
        {
            try
            {
                int id_pagina = Convert.ToInt32(form["id_pagina"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_del_acessoPagina", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/recurso/inserir")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage InserirAcessoRecurso(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_ins_acessoRecurso", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/recurso/remover")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage RemoverAcessoRecurso(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_del_acessoRecurso", parametros);
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
