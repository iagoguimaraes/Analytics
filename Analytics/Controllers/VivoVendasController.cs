using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/vivo/dashboard")]
    public class VivoVendasController : ApiController
    {

        [Route("vendas/marcacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPromessaSMS(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_retornoUra", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("vendas/checkSituacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CheckSMS(FormDataCollection form)
        {
            try
            {   


                string id_chamada = form["id_chamada"];
                int id_situacao = Convert.ToInt32(form["id_situacao"]);
                bool venda = false;

                if(form["venda"].Equals(""))
                {
                    venda = false;
                } else
                {
                    venda = Convert.ToBoolean(form["venda"]);
                }

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_chamada", id_chamada);
                    parametros.Add("situacao", Convert.ToInt32(id_situacao).ToString());
                    parametros.Add("venda", Convert.ToInt16(venda).ToString());

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_retornoChamada", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}