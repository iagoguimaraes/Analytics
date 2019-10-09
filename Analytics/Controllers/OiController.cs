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
                DateTime dtini_2 = Convert.ToDateTime(form["dtini_2"]);
                DateTime dtfim_2 = Convert.ToDateTime(form["dtfim_2"]);

                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);

                int horaini_2 = Convert.ToInt16(form["horaini_2"]);
                int horafim_2 = Convert.ToInt16(form["horafim_2"]);


                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);


                DataTable campanha_2 = JsonConvert.DeserializeObject<DataTable>(form["campanha_2"]);
                DataTable segmento_2 = JsonConvert.DeserializeObject<DataTable>(form["segmento_2"]);
                DataTable produto_2 = JsonConvert.DeserializeObject<DataTable>(form["produto_2"]);
                DataTable supervisor_2 = JsonConvert.DeserializeObject<DataTable>(form["supervisor_2"]);

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
                    parametros.Add("dtini_2", dtini_2.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_2", dtfim_2.ToString("yyyy-MM-dd"));

                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    parametros.Add("horaini_2", horaini_2);
                    parametros.Add("horafim_2", horafim_2);


                    parametros.Add("campanha", campanha);
                    parametros.Add("segmento", segmento);
                    parametros.Add("produto", produto);
                    parametros.Add("supervisor", supervisor);


                    parametros.Add("campanha_2", campanha_2);
                    parametros.Add("segmento_2", segmento_2);
                    parametros.Add("produto_2", produto_2);
                    parametros.Add("supervisor_2", supervisor_2);

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

        [Route("dashboard/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseAtiva(FormDataCollection form)
        {
            try
            {
                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable proposta = JsonConvert.DeserializeObject<DataTable>(form["proposta"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("campanhas", campanha);
                    parametros.Add("segmentos", segmentacao);
                    parametros.Add("produtos", produto);
                    parametros.Add("propostas", proposta);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
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
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/recebimentocomissao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRecebimentoComissao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_recebimento_comissao", parametros);
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
                int meta_fixa_r1 = Convert.ToInt32(form["meta_fixa_r1"].ToString().Replace(".", ""));
                int meta_fixa_r2 = Convert.ToInt32(form["meta_fixa_r2"].ToString().Replace(".", ""));
                int meta_movel_r1 = Convert.ToInt32(form["meta_movel_r1"].ToString().Replace(".", ""));
                int meta_tv = Convert.ToInt32(form["meta_tv"].ToString().Replace(".", ""));
                int meta_fixa_r1_promessa = Convert.ToInt32(form["meta_fixa_r1_promessa"].ToString().Replace(".", ""));
                int meta_fixa_r2_promessa = Convert.ToInt32(form["meta_fixa_r2_promessa"].ToString().Replace(".", ""));
                int meta_movel_r1_promessa = Convert.ToInt32(form["meta_movel_r1_promessa"].ToString().Replace(".", ""));
                int meta_tv_promessa = Convert.ToInt32(form["meta_tv_promessa"].ToString().Replace(".", ""));


                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("meta_fixa_r1", meta_fixa_r1);
                    parametros.Add("meta_fixa_r2", meta_fixa_r2);
                    parametros.Add("meta_movel_r1", meta_movel_r1);
                    parametros.Add("meta_tv", meta_tv);
                    parametros.Add("meta_fixa_r1_promessa", meta_fixa_r1_promessa);
                    parametros.Add("meta_fixa_r2_promessa", meta_fixa_r2_promessa);
                    parametros.Add("meta_movel_r1_promessa", meta_movel_r1_promessa);
                    parametros.Add("meta_tv_promessa", meta_tv_promessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_cadmeta", parametros);
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
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_metas", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
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

        [Route("dashboard/acaomassiva")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAcaoMassiva(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentos = JsonConvert.DeserializeObject<DataTable>(form["segmentos"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentos", segmentos);
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acaomassiva", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/cadcapacity")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CadCapacity(FormDataCollection form)
        {
            try
            {
                DataTable capacity = JsonConvert.DeserializeObject<DataTable>(form.ReadAsNameValueCollection().Keys[0].ToString());

                capacity.Rows[0].Delete();
              

                using (SqlHelper sql = new SqlHelper("CUBO_OI_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("capacity", capacity);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_fatoCapacity_cadastro", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/capacity")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEditarCapacity(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OI_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_editar", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_OI_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_gerencial", parametros);
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
