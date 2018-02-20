using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Analytics
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

            // obtem dados da sessao
            Sessao sessao = (Sessao)actionExecutedContext.Request.Properties["Sessao"];

            // id do recurso
            int id_recurso = (int)actionExecutedContext.Request.Properties["id_recurso"];

            // registra a requisição
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data_requisicao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("tempo_execucao", stopwatch.ElapsedMilliseconds.ToString());
                    parametros.Add("id_sessao", sessao.id_sessao.ToString());
                    parametros.Add("id_recurso", id_recurso.ToString());

                    sql.ExecuteProcedureDataTable("sp_ins_requisicao", parametros);
                }
            }
            catch { }

        }
    }
}