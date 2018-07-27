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
    [RoutePrefix("api/oi")]
    public class OiController : ApiController
    {
        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                //DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    //parametros.Add("carteiras", carteiras);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("equipes", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                //DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    //parametros.Add("carteiras", carteiras);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("equipes", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/recebimento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRecebimento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DateTime dtiniPag = Convert.ToDateTime(form["dtiniPag"]);
                DateTime dtfimPag = Convert.ToDateTime(form["dtfimPag"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtiniPag", dtiniPag.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfimPag", dtfimPag.ToString("yyyy-MM-dd"));
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_recebimento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/comparativo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComparativo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DateTime dtini2 = Convert.ToDateTime(form["dtini_2"]);
                DateTime dtfim2 = Convert.ToDateTime(form["dtfim_2"]);

                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                DataTable campanhas2 = JsonConvert.DeserializeObject<DataTable>(form["campanhas2"]);
                DataTable segmentos2 = JsonConvert.DeserializeObject<DataTable>(form["segmentos2"]);
                DataTable produtos2 = JsonConvert.DeserializeObject<DataTable>(form["produtos2"]);

                string procedure = "sp_dashboard_comparativo_hora";

                if (form["visao"] == "hora")
                    procedure = "sp_dashboard_comparativo_hora";
                if (form["visao"] == "dia")
                    procedure = "sp_dashboard_comparativo_dia";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_dashboard_comparativo_dia_semana";
                if (form["visao"] == "semana")
                    procedure = "sp_dashboard_comparativo_semana";
                if (form["visao"] == "mes")
                    procedure = "sp_dashboard_comparativo_mes";

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_2", dtini2.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_2", dtfim2.ToString("yyyy-MM-dd"));

                    parametros.Add("campanha", campanhas);
                    parametros.Add("segmento", segmentos);
                    parametros.Add("produto", produtos);

                    parametros.Add("campanha_2", campanhas2);
                    parametros.Add("segmento_2", segmentos2);
                    parametros.Add("produto_2", produtos2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/grupo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardGrupo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable grupos = JsonConvert.DeserializeObject<DataTable>(form["grupo"]);

                string procedure = "sp_dashboard_grupo";

                //if (form["visao"] == "andamento")
                //    procedure = "sp_dashboard_grupo";
                //if (form["visao"] == "vencimento")
                //    procedure = "sp_dashboard_grupoVencimento";

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);
                    parametros.Add("grupos", grupos);


                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
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
