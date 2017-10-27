using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using System.Data;
using DAL;
using Newtonsoft.Json;
using System.Net;
using System.DirectoryServices.AccountManagement;

namespace BLL
{
    public class bAutorizacao
    {
        /// <summary>
        /// insere registro para a sessão (caso o usuário e senha estejam corretos) e retorna o token
        /// </summary>
        public string ObterToken(string login, string senha)
        {
            try
            {                           
                // verica as credencias do AD
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "CREDITCASH"))
                {
                    bool isValid = pc.ValidateCredentials(login, senha);
                    if (!isValid)
                        throw new Exception("Usuário e/ou senha incorreto(s)");
                }

                // obtem o usuário nos cadastro do analytics
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtUsuario = dal.ObterUsuario(login, new EncryptHelper().Encrypt(senha));

                if (dtUsuario.Rows.Count == 0)
                    throw new Exception("Usuário não cadastrado ou desativado no Analytics");

                // insere um registro de sessao
                Usuario usuario = new Usuario(dtUsuario.Rows[0]);
                DataTable dtSessao = dal.InserirSessao(DateTime.Now, usuario, DateTime.Now.AddDays(1));

                // gera token (id_sessao encriptografado)
                Sessao sessao = new Sessao(dtSessao.Rows[0]);
                string token = new EncryptHelper().Encrypt(sessao.id_sessao.ToString());

                // retorna o token  
                return token;
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// código para verificar se a validação do captcha foi feito com sucesso
        /// </summary>
        /// <param name="encodedResponse">codigo gerado pelo google no clientside</param>
        /// <returns>valido ou inválido</returns>
        public bool ValidarCaptcha(string encodedResponse)
        {
            try
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
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }

        }

        /// <summary>
        /// obtem o token, deserializa e retorna a sessao do usuário
        /// </summary>
        /// <param name="token">token encriptografado</param>
        /// <returns>objecto sessao</returns>
        public Sessao GetSessao(string token)
        {
            try
            {
                string id_sessao = new EncryptHelper().Decrypt(token);
                DataTable dtSessao = new dAutorizaocao().GetSessao(id_sessao);
                return new Sessao(dtSessao.Rows[0]);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// renova a data de expiracao de uma sessao em + 1 dia
        /// </summary>
        /// <param name="sessao">sessao</param>
        public void RenovarSessao(Sessao sessao)
        {
            try
            {
                new dAutorizaocao().RenovarSessao(sessao.id_sessao, DateTime.Now.AddDays(1));
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// verifica se o grupo tem acesso ao path
        /// retorna também o id do recurso (caso exista)
        /// </summary>
        public bool AcessoRecurso(int id_grupo, string path, out int id_recurso)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtAcesso = dal.AcessoRecurso(id_grupo, path);

                if (dtAcesso.Rows.Count == 0)
                {
                    id_recurso = 0;
                    return false;
                }
                else
                {
                    id_recurso = Convert.ToInt32(dtAcesso.Rows[0]["id_recurso"]);

                    if (string.IsNullOrEmpty(dtAcesso.Rows[0]["id_grupo"].ToString()))
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// registra a requisição no banco
        /// </summary>
        public void RegistrarRequisicao(long tempo_execucao, int id_sessao, int id_recurso)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                dal.RegistrarRequisicao(DateTime.Now, tempo_execucao, id_sessao, id_recurso);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// obtem as paginas que um determinado grupo possui acesso
        /// </summary>
        public List<Pagina> AcessoPagina(int id_grupo)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtAcesso = dal.AcessoPagina(id_grupo);

                List<Pagina> paginas = new List<Pagina>();

                foreach (DataRow row in dtAcesso.Rows)
                    paginas.Add(new Pagina(row));

                return paginas;
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
