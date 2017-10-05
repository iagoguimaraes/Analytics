using BLL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace API
{
    public class Authorization : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                // verifica se o token existe
                var headers = actionContext.Request.Headers;
                if (!headers.Contains("Token"))
                    return false;

                // obtem token, deserializa e obtem sessao
                string token = headers.GetValues("Token").First();
                string decrypt = new EncryptHelper().Decrypt(token);
                Sessao sessao = new Sessao(decrypt);

                // guarda sessao nas props da requisição
                actionContext.Request.Properties["Sessao"] = sessao;

                // obtem o path, verifica o acesso e armazena o id do recurso
                string path = actionContext.Request.RequestUri.AbsolutePath;
                bAutorizacao bll = new bAutorizacao();
                int id_recurso = 0;
                bool autorizado = bll.AcessoRecurso(sessao.id_grupo, path, out id_recurso);
                actionContext.Request.Properties["id_recurso"] = id_recurso;

                return autorizado;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}