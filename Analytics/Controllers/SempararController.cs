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
    [RoutePrefix("api/semparar")]
    public class SempararController : ApiController
    {

        #region HUMANO

        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_filtros_humano");
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
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_humano", parametros);
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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_humano", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
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
        public HttpResponseMessage DashboardEfetvidade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);

                string procedure = "sp_dashboard_efetividade_humano_vencimento";

                if (form["visao"] == "andamento")
                    procedure = "sp_dashboard_efetividade_humano";
                if (form["visao"] == "vencimento")
                    procedure = "sp_dashboard_efetividade_humano_vencimento";
                if (form["visao"] == "pagamento")
                    procedure = "sp_dashboard_efetividade_humano_pagamento";

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);
                    parametros.Add("faixaAtraso", faixaAtraso);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresas", empresas);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);

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

                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/paglote")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagLote(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_paglote", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/receptivo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardReceptivo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("origem", origem);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_receptivo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/projecao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProjecao(FormDataCollection form)
        {
            try
            {
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();


                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_projecao");
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

                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable devedor = JsonConvert.DeserializeObject<DataTable>(form["devedor"]);

                DataTable empresas_2 = JsonConvert.DeserializeObject<DataTable>(form["empresas_2"]);
                DataTable carteiras_2 = JsonConvert.DeserializeObject<DataTable>(form["carteiras_2"]);
                DataTable faixaAtraso_2 = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso_2"]);
                DataTable plano_2 = JsonConvert.DeserializeObject<DataTable>(form["plano_2"]);
                DataTable devedor_2 = JsonConvert.DeserializeObject<DataTable>(form["devedor_2"]);

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

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
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

                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("plano", plano);
                    parametros.Add("devedor", devedor);

                    parametros.Add("empresas_2", empresas_2);
                    parametros.Add("carteiras_2", carteiras_2);
                    parametros.Add("faixaAtraso_2", faixaAtraso_2);
                    parametros.Add("plano_2", plano_2);
                    parametros.Add("devedor_2", devedor_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/rechamada")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRechamada(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_rechamada", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region DIGITAL

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
                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanha", campanha);

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
                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanha", campanha);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/multicanal")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardMultiCanal(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_mktzap", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/boletosms")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEnvioSms(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);
                bool carregar = Convert.ToBoolean(form["carregar"]);
                DataTable discador = JsonConvert.DeserializeObject<DataTable>(form["discador"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("filas", filas);
                    parametros.Add("carregar", carregar ? 1 : 0);
                    parametros.Add("discador", discador);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_boleto_sms", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
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
        public HttpResponseMessage DashboardProducaoDigitalCallflex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseAtivaDigital(FormDataCollection form)
        {
            try
            {
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixaAtraso", faixaAtraso);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltrosDigital()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
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

        [Route("dashboard/digital/download")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadExcelDigital(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));


                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_analitico_promessa", parametros);
                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=PROMESSASDIGITAL_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region RECEPTIVOAD 

        [Route("dashboard/receptivoad/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraReceptivoDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("filas", filas);
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_receptivo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/receptivoad/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoReceptivoDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_SEMPARAR_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("filas", filas);
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_receptivo", parametros);
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