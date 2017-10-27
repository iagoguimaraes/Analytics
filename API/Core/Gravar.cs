using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BLL;
using MDL;

namespace API
{
    public class Gravar : ActionFilterAttribute
    {
        private const string StopwatchKey = "StopwatchFilter.Value";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            // ao iniciar execução, começa a contar o tempo
            actionContext.Request.Properties[StopwatchKey] = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            // ao terminar execução, para de contar o tempo
            Stopwatch stopwatch = (Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey];

            // obtem dados do cliente
            Sessao sessao = (Sessao)actionExecutedContext.Request.Properties["Sessao"];
            int id_recurso = (int)actionExecutedContext.Request.Properties["id_recurso"];

            // registra a requisição
            try
            {
                new bAutorizacao().RegistrarRequisicao(stopwatch.ElapsedMilliseconds, sessao.id_sessao, id_recurso);
            }
            catch {}
            
        }
    }
}