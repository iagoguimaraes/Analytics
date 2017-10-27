using BLL;
using MDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/autenticacao")]
    public class AutenticacaoController : ApiController
    {
        [Route("logar")]
        [HttpPost]
        public HttpResponseMessage Logar(FormDataCollection form)
        {
            try
            {
                string login = form["login"];
                string senha = form["senha"];
                string recaptcha = form["recaptcha"];

                bAutorizacao bll = new bAutorizacao();

                if (!bll.ValidarCaptcha(recaptcha))
                    throw new Exception("Captcha não fornecido");

                string token = bll.ObterToken(login, senha);

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("getPaginas")]
        [HttpGet]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage GetPagina()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];
                List<Pagina> paginas = new bAutorizacao().AcessoPagina(sessao.id_grupo);
                return Request.CreateResponse(HttpStatusCode.OK, paginas);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
