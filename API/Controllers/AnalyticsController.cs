using BLL;
using MDL;
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

        [Route("diariobordo/consultar")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage ConsultarDiarioBordo(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string empresas = form["empresas"];
                string carteiras = form["carteiras"];
                string ocorrencias = form["ocorrencias"];
                string usuarios = form["usuarios"];

                DataSet resultado = new bAnalytics().ConsultarDiarioBordo(dtini, dtfim, empresas, carteiras, ocorrencias, usuarios);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("diariobordo/opcoes")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage OpcoesDiarioBordo()
        {
            try
            {
                DataSet resultado = new bAnalytics().OpcoesDiarioBordo();
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("diariobordo/inserir")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage InserirDiarioBordo(FormDataCollection form)
        {
            try
            {
                string data = form["data"];
                string hora = form["hora"];
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                string descricao = form["descricao"];

                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                new bAnalytics().InserirDiarioBordo(data, hora, id_empresa, id_carteira, id_ocorrencia, sessao.id_usuario, descricao);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("diariobordo/editar")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage EditarDiarioBordo(FormDataCollection form)
        {
            try
            {
                int id_diario_bordo = Convert.ToInt32(form["id"]);
                string data = form["data"];
                string hora = form["hora"];
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                string descricao = form["descricao"];

                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                new bAnalytics().EditarDiarioBordo(id_diario_bordo, data, hora, id_empresa, id_carteira, id_ocorrencia, sessao.id_usuario, descricao);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("diariobordo/remover")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage RemoverDiarioBordo(FormDataCollection form)
        {
            try
            {
                int id_diario_bordo = Convert.ToInt32(form["id"]);

                new bAnalytics().RemoverDiarioBordo(id_diario_bordo);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
