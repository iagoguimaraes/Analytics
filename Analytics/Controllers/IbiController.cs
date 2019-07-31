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
    [RoutePrefix("api/ibi")]
    public class IbiController : ApiController
    {
        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
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
                DataTable credores = JsonConvert.DeserializeObject<DataTable>(form["credores"]);
                DataTable fases = JsonConvert.DeserializeObject<DataTable>(form["fases"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("credores", credores);
                    parametros.Add("fases", fases);
                    parametros.Add("supervisor", supervisor);

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
                DataTable credores = JsonConvert.DeserializeObject<DataTable>(form["credores"]);
                DataTable fases = JsonConvert.DeserializeObject<DataTable>(form["fases"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("credores", credores);
                    parametros.Add("fases", fases);
                    parametros.Add("supervisor", supervisor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable credores = JsonConvert.DeserializeObject<DataTable>(form["credores"]);
                DataTable fases = JsonConvert.DeserializeObject<DataTable>(form["fases"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("credores", credores);
                    parametros.Add("fases", fases);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseAtiva(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable credores = JsonConvert.DeserializeObject<DataTable>(form["credores"]);
                DataTable fases = JsonConvert.DeserializeObject<DataTable>(form["fases"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("credores", credores);
                    parametros.Add("fases", fases);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/efetividade")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEfetvidade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DateTime dtini_imp = Convert.ToDateTime(form["dtini_inc"]);
                DateTime dtfim_imp = Convert.ToDateTime(form["dtfim_inc"]);
                DataTable credores = JsonConvert.DeserializeObject<DataTable>(form["credores"]);
                DataTable fases = JsonConvert.DeserializeObject<DataTable>(form["fases"]);

                string procedure = "sp_dashboard_efetividade_vencimento";

                if (form["visao"] == "andamento")
                    procedure = "sp_dashboard_efetividade_andamento";
                if (form["visao"] == "vencimento")
                    procedure = "sp_dashboard_efetividade_vencimento";

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_imp", dtini_imp.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_imp", dtfim_imp.ToString("yyyy-MM-dd"));
                    parametros.Add("credores", credores);
                    parametros.Add("fases", fases);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/ocupacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardOcupacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/metas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoPlanejamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixas", faixas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_metas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/cadmetas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CadMetaHumano(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int meta_atraso2 = Convert.ToInt32(form["meta_atraso2"].ToString().Replace(".", ""));
                int meta_atraso3  = Convert.ToInt32(form["meta_atraso3"].ToString().Replace(".", ""));
                int meta_atraso4  = Convert.ToInt32(form["meta_atraso4"].ToString().Replace(".", ""));
                int meta_atraso5  = Convert.ToInt32(form["meta_atraso5"].ToString().Replace(".", ""));
                int meta_atraso6  = Convert.ToInt32(form["meta_atraso6"].ToString().Replace(".", ""));
                int meta_atraso7  = Convert.ToInt32(form["meta_atraso7"].ToString().Replace(".", ""));
                int meta_atraso8  = Convert.ToInt32(form["meta_atraso8"].ToString().Replace(".", ""));
                int meta_atraso9  = Convert.ToInt32(form["meta_atraso9"].ToString().Replace(".", ""));
                int meta_atraso10 = Convert.ToInt32(form["meta_atraso10"].ToString().Replace(".", ""));


                int meta_pp_atraso2  = Convert.ToInt32(form["meta_pp_atraso2"].ToString().Replace(".", ""));
                int meta_pp_atraso3  = Convert.ToInt32(form["meta_pp_atraso3"].ToString().Replace(".", ""));
                int meta_pp_atraso4  = Convert.ToInt32(form["meta_pp_atraso4"].ToString().Replace(".", ""));
                int meta_pp_atraso5  = Convert.ToInt32(form["meta_pp_atraso5"].ToString().Replace(".", ""));
                int meta_pp_atraso6  = Convert.ToInt32(form["meta_pp_atraso6"].ToString().Replace(".", ""));
                int meta_pp_atraso7  = Convert.ToInt32(form["meta_pp_atraso7"].ToString().Replace(".", ""));
                int meta_pp_atraso8  = Convert.ToInt32(form["meta_pp_atraso8"].ToString().Replace(".", ""));
                int meta_pp_atraso9  = Convert.ToInt32(form["meta_pp_atraso9"].ToString().Replace(".", ""));
                int meta_pp_atraso10 = Convert.ToInt32(form["meta_pp_atraso10"].ToString().Replace(".", ""));

                using (SqlHelper sql = new SqlHelper("CUBO_IBI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("meta_atraso2", meta_atraso2);
                    parametros.Add("meta_atraso3", meta_atraso3);
                    parametros.Add("meta_atraso4", meta_atraso4);
                    parametros.Add("meta_atraso5", meta_atraso5);
                    parametros.Add("meta_atraso6", meta_atraso6);
                    parametros.Add("meta_atraso7", meta_atraso7);
                    parametros.Add("meta_atraso8", meta_atraso8);
                    parametros.Add("meta_atraso9", meta_atraso9);
                    parametros.Add("meta_atraso10", meta_atraso10);


                    parametros.Add("meta_pp_atraso2", meta_pp_atraso2);
                    parametros.Add("meta_pp_atraso3", meta_pp_atraso3);
                    parametros.Add("meta_pp_atraso4", meta_pp_atraso4);
                    parametros.Add("meta_pp_atraso5", meta_pp_atraso5);
                    parametros.Add("meta_pp_atraso6", meta_pp_atraso6);
                    parametros.Add("meta_pp_atraso7", meta_pp_atraso7);
                    parametros.Add("meta_pp_atraso8", meta_pp_atraso8);
                    parametros.Add("meta_pp_atraso9", meta_pp_atraso9);
                    parametros.Add("meta_pp_atraso10", meta_pp_atraso10);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_cadmeta", parametros);
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
