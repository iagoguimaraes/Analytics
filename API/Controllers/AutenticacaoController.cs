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

                if (!Validate(recaptcha))
                    throw new Exception("Captcha não fornecido");

                Sessao sessao = new bAutorizacao().InserirSessao(login, senha);
                string token = new EncryptHelper().Encrypt(sessao.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private bool Validate(string encodedResponse)
        {
            if (string.IsNullOrEmpty(encodedResponse)) return false;

            var secret = "6LdmFjYUAAAAALBVVP4mgi7Jvfj8hSP14XgKXUQw";
            if (string.IsNullOrEmpty(secret)) return false;

            WebClient client = new WebClient();
            WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
            proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
            client.Proxy = proxy;

            var googleReply = client.DownloadString(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={encodedResponse}");

            return JsonConvert.DeserializeObject<RecaptchaResponse>(googleReply).Success;
        }

        [Route("getPaginas")]
        [HttpGet]
        [Authorization]
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
