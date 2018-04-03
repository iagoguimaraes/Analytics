using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.DirectoryServices.AccountManagement;
using System.Data;

namespace Analytics.Controllers
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

                // valida o captcha
                //Captcha captcha = new Captcha();
                //if (!captcha.ValidarCaptcha(recaptcha))
                //    throw new Exception("Captcha não fornecido");

                // verica as credencias do AD
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "creditcash.com.br"))
                {
                    bool isValid = pc.ValidateCredentials(login, senha);
                    if (!isValid)
                        throw new Exception("Usuário e/ou senha incorreto(s)");
                }

                // recupera o usuário analytics
                Usuario usuario;
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("login", login);

                    DataTable dtUsuario = sql.ExecuteProcedureDataTable("sp_sel_usuario_bylogin", parametros);

                    if (dtUsuario.Rows.Count == 0)
                        throw new Exception("Usuário não cadastrado ou desativado no Analytics");

                    usuario = new Usuario(dtUsuario.Rows[0]);
                }

                // inserir um registro de sessão no banco de dados
                Sessao sessao;
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data_criacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("id_usuario", usuario.id_usuario.ToString());
                    parametros.Add("id_grupo", usuario.id_grupo.ToString());
                    parametros.Add("data_expiracao", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"));

                    DataTable dtSessao = sql.ExecuteProcedureDataTable("sp_ins_sessao", parametros);
                    sessao = new Sessao(dtSessao.Rows[0]);
                }

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