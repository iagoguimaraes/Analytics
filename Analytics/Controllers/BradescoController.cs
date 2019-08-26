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
    [RoutePrefix("api/bradesco")]
    public class BradescoController : ApiController
    {
        [Route("dashboard/filtros")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros(FormDataCollection form)
        {
            try
            {
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros",parametros);
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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);                
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);
                    parametros.Add("empresa", empresa);
                    parametros.Add("bloco", bloco);

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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);


                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);
                    parametros.Add("empresa", empresa);
                    parametros.Add("bloco", bloco);


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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresa", empresa);
                    parametros.Add("bloco", bloco);

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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresa", empresa);
                    parametros.Add("bloco", bloco);

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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                string visao = form["visao"].ToString();
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);


                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_imp", dtini_imp.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_imp", dtfim_imp.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresa", empresa);
                    parametros.Add("visao", visao);                    
                    parametros.Add("bloco", bloco);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
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
                DateTime dtini_2 = Convert.ToDateTime(form["dtini_2"]);
                DateTime dtfim_2 = Convert.ToDateTime(form["dtfim_2"]);

                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);

                int horaini_2 = Convert.ToInt16(form["horaini_2"]);
                int horafim_2 = Convert.ToInt16(form["horafim_2"]);


                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable fase = JsonConvert.DeserializeObject<DataTable>(form["fase"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                //DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                DataTable carteira_2 = JsonConvert.DeserializeObject<DataTable>(form["carteira_2"]);
                DataTable fase_2 = JsonConvert.DeserializeObject<DataTable>(form["fase_2"]);

                DataTable supervisor_2 = JsonConvert.DeserializeObject<DataTable>(form["supervisor_2"]);
                //DataTable equipe_2 = JsonConvert.DeserializeObject<DataTable>(form["equipe_2"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);

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

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_2", dtini_2.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_2", dtfim_2.ToString("yyyy-MM-dd"));

                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    parametros.Add("horaini_2", horaini_2);
                    parametros.Add("horafim_2", horafim_2);

                    parametros.Add("carteira", carteira);
                    parametros.Add("fase", fase);
                    parametros.Add("supervisor", supervisor);

                    parametros.Add("carteira_2", carteira_2);
                    parametros.Add("fase_2", fase_2);
                    parametros.Add("supervisor_2", supervisor_2);

                    parametros.Add("empresa", empresa);
                    parametros.Add("bloco", bloco);

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
                

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
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
        public HttpResponseMessage DashboardPlanejamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresa", empresa);

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
        public HttpResponseMessage CadMeta(FormDataCollection form)
        {
            try
            {
      

                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int id_segmento = Convert.ToInt32(form["id_segmento"]);
                int carteira = Convert.ToInt32(form["carteira"]);


                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable cpca = JsonConvert.DeserializeObject<DataTable>(form["cpca"]);
                DataTable promessa = JsonConvert.DeserializeObject<DataTable>(form["promessa"]);


                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("id_segmento", id_segmento);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("cpca", cpca);
                    parametros.Add("promessa", promessa);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_cadmeta", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/receptivo/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraRec(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_receptivo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/receptivo/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoRec(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_receptivo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/gerencial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardGerencial(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable bloco = JsonConvert.DeserializeObject<DataTable>(form["bloco"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bloco", bloco);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_gerencial", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #region RecursosAntigos
        
        [Route("dashboard/eavm/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoEavm(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_eavm", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/eavm/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraEavm(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_eavm", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/eavm/ocupacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardOcupacaoEavm(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao_eavm", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/eavm/metas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPlanejamentoEavm(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_metas_eavm", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/eavm/cadmetas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CadMetaEavm(FormDataCollection form)
        {
            try
            {


                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int id_segmento = 0;


                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable cpca = JsonConvert.DeserializeObject<DataTable>(form["cpca"]);
                DataTable promessa = JsonConvert.DeserializeObject<DataTable>(form["promessa"]);


                using (SqlHelper sql = new SqlHelper("CUBO_BRADESCO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("id_segmento", id_segmento);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("cpca", cpca);
                    parametros.Add("promessa", promessa);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_cadmeta", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion





    }
}
