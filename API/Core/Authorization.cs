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
                var headers = actionContext.Request.Headers;
                if (!headers.Contains("Token"))
                    return false;

                string token = headers.GetValues("Token").First();
                string decrypt = new EncryptHelper().Decrypt(token);
                Sessao sessao = new Sessao(decrypt);

                string path = actionContext.Request.RequestUri.AbsolutePath;
                bAutorizacao bll = new bAutorizacao();

                return bll.AcessoRecurso(sessao.id_grupo, path);
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}