using BLL;
using MDL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API
{
    public class GravarRequisicao : ActionFilterAttribute
    {
        private const string StopwatchKey = "StopwatchFilter.Value";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            actionContext.Request.Properties[StopwatchKey] = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            Stopwatch stopwatch = (Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey];
            Sessao sessao = (Sessao)actionExecutedContext.Request.Properties["Sessao"];
            int id_recurso = (int)actionExecutedContext.Request.Properties["id_recurso"];

            try
            {
                new bAutorizacao().RegistrarRequisicao(stopwatch.ElapsedMilliseconds, sessao.id_sessao, id_recurso);
            }
            catch {}
        }
    }
}