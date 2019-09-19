using Analytics.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/sky")]
    public class SkyHumanoController : ApiController
    {
        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
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

        [Route("dashboard/humano/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]); //@DTINI

                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);
                DataTable ocorrencia = JsonConvert.DeserializeObject<DataTable>(form["ocorrencia"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("tenure", tenure);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_new", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }             
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);
                DataTable operador = JsonConvert.DeserializeObject<DataTable>(form["operador"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("tenure", tenure);
                    parametros.Add("operador", operador);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_new", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/comparativo")]
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
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable ocorrencia = JsonConvert.DeserializeObject<DataTable>(form["ocorrencia"]);

                DataTable carteira_2 = JsonConvert.DeserializeObject<DataTable>(form["carteira_2"]);
                DataTable segmentacao_2 = JsonConvert.DeserializeObject<DataTable>(form["segmentacao_2"]);
                DataTable tenure_2 = JsonConvert.DeserializeObject<DataTable>(form["tenure_2"]);

                DataTable supervisor_2 = JsonConvert.DeserializeObject<DataTable>(form["supervisor_2"]);
                DataTable ocorrencia_2 = JsonConvert.DeserializeObject<DataTable>(form["ocorrencia_2"]);



                string procedure = "sp_dashboard_comparativo_hora" + form["conceito"] + "";
                if (form["visao"] == "hora")
                    procedure = "sp_dashboard_comparativo_hora" + form["conceito"] + "";
                if (form["visao"] == "dia")
                    procedure = "sp_dashboard_comparativo_dia" + form["conceito"] + "";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_dashboard_comparativo_dia_semana" + form["conceito"] + "";
                if (form["visao"] == "semana")
                    procedure = "sp_dashboard_comparativo_semana" + form["conceito"] + "";
                if (form["visao"] == "mes")
                    procedure = "sp_dashboard_comparativo_mes" + form["conceito"] + "";

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
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
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("tenure", tenure);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("ocorrencia", ocorrencia);

                    parametros.Add("carteira_2", carteira_2);
                    parametros.Add("segmentacao_2", segmentacao_2);
                    parametros.Add("tenure_2", tenure_2);
                    parametros.Add("supervisor_2", supervisor_2);
                    parametros.Add("ocorrencia_2", ocorrencia_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/robo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRobo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_robo_sky", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("segmentacoes", segmentacoes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseAtiva(FormDataCollection form)
        {
            try
            {
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("tenure", tenure);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/acionamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Acionamento(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkSupervisor = form["chkSupervisor"];
                string chkEquipe = form["chkEquipe"];
                string chkCarteira = form["chkCarteira"];
                string chkSegmentacao = form["chkSegmentacao"];
                string chkTenure = form["chkTenure"];

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);                    

                    parametros.Add("supervisor", supervisor);
                    parametros.Add("tenure", tenure);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    parametros.Add("chkSupervisor", chkSupervisor);
                    parametros.Add("chkEquipe", chkEquipe);
                    parametros.Add("chkCarteira", chkCarteira);
                    parametros.Add("chkSegmentacao", chkSegmentacao);
                    parametros.Add("chkTenure", chkTenure);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acionamento", parametros);

                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }


        }

        [Route("dashboard/humano/download")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadExcel(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkSupervisor = form["chkSupervisor"];
                string chkEquipe = form["chkEquipe"];
                string chkCarteira = form["chkCarteira"];
                string chkSegmentacao = form["chkSegmentacao"];
                string chkTenure = form["chkTenure"];

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);

                    parametros.Add("supervisor", supervisor);
                    parametros.Add("tenure", tenure);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    parametros.Add("chkSupervisor", chkSupervisor);
                    parametros.Add("chkEquipe", chkEquipe);
                    parametros.Add("chkCarteira", chkCarteira);
                    parametros.Add("chkSegmentacao", chkSegmentacao);
                    parametros.Add("chkTenure", chkTenure);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_SKY_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/efetividade")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEfetividade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);                
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                string visao = form["visao"];

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("tenure", tenure);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("visao", visao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/questionario")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardQuestionario(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable resposta = JsonConvert.DeserializeObject<DataTable>(form["resposta"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("resposta", resposta);
                    parametros.Add("carteira", carteira);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_questionario", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/ocupacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardOcupacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable discador = JsonConvert.DeserializeObject<DataTable>(form["discador"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);
                    parametros.Add("discador", discador);
                    parametros.Add("supervisor", supervisor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/atemporal")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAtemporal(FormDataCollection form)
        {
            try
            {
                int dtini = Convert.ToInt32(form["dtini"]);
                int dtfim = Convert.ToInt32(form["dtfim"]);
                DataTable periodo = JsonConvert.DeserializeObject<DataTable>(form["periodo"]);
                string diautil = form["diautil"];
                string feriado = form["feriado"];
                DataTable diasemana = JsonConvert.DeserializeObject<DataTable>(form["diasemana"]);
                DataTable semanames = JsonConvert.DeserializeObject<DataTable>(form["semanames"]);


                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable ocorrencia = JsonConvert.DeserializeObject<DataTable>(form["ocorrencia"]);
                DataTable classificacao = JsonConvert.DeserializeObject<DataTable>(form["classificacao"]);

                //DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("periodo", periodo);
                    parametros.Add("diautil", diautil);
                    parametros.Add("feriado", feriado);
                    parametros.Add("diaSemana", diasemana);
                    parametros.Add("semanaMes", semanames);
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("tenure", tenure);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("classificacao", classificacao);
                    //parametros.Add("equipe", equipe);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_atemporal", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/comite")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComite(FormDataCollection form)
        {
            try
            {

                DataTable periodo = JsonConvert.DeserializeObject<DataTable>(form["periodo"]);
                string diautil = form["diautil"];
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable tenure = JsonConvert.DeserializeObject<DataTable>(form["tenure"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                //DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("periodo", periodo);
                    parametros.Add("diautil", diautil);
                    parametros.Add("carteira", carteira);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("tenure", tenure);
                    parametros.Add("supervisor", supervisor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_comite", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/comparativo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComparativoDigital(FormDataCollection form)
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


                string procedure = "sp_dashboard_comparativo_digital_hora";

                if (form["visao"] == "hora")
                    procedure = "sp_dashboard_comparativo_digital_hora";
                if (form["visao"] == "dia")
                    procedure = "sp_dashboard_comparativo_digital_dia";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_dashboard_comparativo_digital_dia_semana";
                if (form["visao"] == "semana")
                    procedure = "sp_dashboard_comparativo_digital_semana";
                if (form["visao"] == "mes")
                    procedure = "sp_dashboard_comparativo_digital_mes";

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
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

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/callflex/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraDigitalCallflex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_callflex", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/callflex/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoDigitalCallFlex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SKY_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_callflex", parametros);
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