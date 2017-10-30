using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using MDL;
using BLL;
using System.Web.Http;
using System.Net;

namespace API
{
    public class Autorizar : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            try
            {
                // obtem o path
                string path = actionContext.Request.RequestUri.AbsolutePath;

                // obtem a sessao
                Sessao sessao = (Sessao)actionContext.Request.Properties["Sessao"];

                // verifica o acesso e armazena o id do recurso
                bAutorizacao bll = new bAutorizacao();
                int id_recurso = 0;
                bool autorizado = bll.AcessoRecurso(sessao.id_grupo, path, out id_recurso);

                if(!autorizado)
                    throw new HttpResponseException(HttpStatusCode.Forbidden);

                // armazena o id do recurso na requisição
                actionContext.Request.Properties["id_recurso"] = id_recurso;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
    }
}