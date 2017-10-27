using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MDL;
using BLL;
using System.Web.Http;
using System.Net;

namespace API
{
    public class Autenticar: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            try
            {
                // verifica se o token existe
                var headers = actionContext.Request.Headers;
                if (!headers.Contains("Token"))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                // obtem o token
                string token = headers.GetValues("Token").First();

                // recupera sessao
                bAutorizacao bll = new bAutorizacao();
                Sessao sessao = bll.GetSessao(token);
                
                // verifica se não expirou a sessao
                if (sessao.data_expiracao < DateTime.Now)
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                // renova sessao
                bll.RenovarSessao(sessao);

                // guarda a sessao na requisição (para metodos que usam)
                actionContext.Request.Properties["Sessao"] = sessao;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }


        }
    }
}