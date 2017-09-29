using BLL;
using MDL;
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

                Sessao sessao = new bAutenticacao().InserirSessao(login, senha);
                string token = new EncryptHelper().Encrypt(sessao.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
