using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Analytics
{
    public class Autorizar : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            try
            {
                // obtem o token
                var headers = actionContext.Request.Headers;
                string token = headers.GetValues("Token").First();

                // verifica se o token existe
                if (token == "null")
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                // recupera sessao
                Sessao sessao = new Sessao(new EncryptHelper().Decrypt(token));

                // verifica se não expirou a sessao
                if (sessao.data_expiracao < DateTime.Now)
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                // guarda a sessao na requisição (para metodos que usam)
                actionContext.Request.Properties["Sessao"] = sessao;

                // obtem o path
                string path = actionContext.Request.RequestUri.AbsolutePath;

                // verifica o acesso e armazena o id do recurso
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario.ToString());
                    parametros.Add("path", path);

                    DataTable dtAcesso = sql.ExecuteProcedureDataTable("sp_sel_acessoRecurso", parametros);

                    if (dtAcesso.Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(dtAcesso.Rows[0]["id_recurso"].ToString()))
                            throw new HttpResponseException(HttpStatusCode.Forbidden);

                        // armazena o id do recurso na requisição
                        actionContext.Request.Properties["id_recurso"] = Convert.ToInt32(dtAcesso.Rows[0]["id_recurso"]);
                    }                   

                }
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }
    }
}