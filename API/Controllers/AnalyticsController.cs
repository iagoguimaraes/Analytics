using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/analytics")]
    public class AnalyticsController : ApiController
    {

        [Route("grupo/consultar")]
        [HttpGet]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage ConsultarGrupo()
        {
            try
            {
                DataSet resultado = new bAnalytics().ConsultarGrupo();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/consultar")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage ConsultarAcesso(FormDataCollection form)
        {
            try
            {
                int id_grupo = Convert.ToInt32(form["grupo"]);

                DataSet resultado = new bAnalytics().ConsultarAcesso(id_grupo);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/pagina/inserir")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage InserirAcessoPagina(FormDataCollection form)
        {
            try
            {
                int id_pagina = Convert.ToInt32(form["id_pagina"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                new bAnalytics().InserirAcessoPagina(id_pagina, id_grupo);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/pagina/remover")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage RemoverAcessoPagina(FormDataCollection form)
        {
            try
            {
                int id_pagina = Convert.ToInt32(form["id_pagina"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                new bAnalytics().RemoverAcessoPagina(id_pagina, id_grupo);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/recurso/inserir")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage InserirAcessoRecurso(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                new bAnalytics().InserirAcessoRecurso(id_recurso, id_grupo);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("acesso/recurso/remover")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage RemoverAcessoRecurso(FormDataCollection form)
        {
            try
            {
                int id_recurso = Convert.ToInt32(form["id_recurso"]);
                int id_grupo = Convert.ToInt32(form["id_grupo"]);

                new bAnalytics().RemoverAcessoRecurso(id_recurso, id_grupo);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
