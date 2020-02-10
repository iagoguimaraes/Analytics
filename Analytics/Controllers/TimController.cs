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
    [RoutePrefix("api/tim")]
    public class TimController : ApiController
    {

        #region DIGITAL

        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
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
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("faixa", faixa);

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
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("faixa", faixa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/btc")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBTC(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);
                DataTable rota = JsonConvert.DeserializeObject<DataTable>(form["rota"]);
                DataTable telefone = JsonConvert.DeserializeObject<DataTable>(form["tptelefone"]);
                DataTable chamada = JsonConvert.DeserializeObject<DataTable>(form["tpchamada"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("faixa", faixa);
                    parametros.Add("rota", rota);
                    parametros.Add("tptelefone", telefone);
                    parametros.Add("tpchamada", chamada);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
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

                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable produtos_2 = JsonConvert.DeserializeObject<DataTable>(form["produtos_2"]);

                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);
                DataTable faixa_2 = JsonConvert.DeserializeObject<DataTable>(form["faixa_2"]);



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

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
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

                    parametros.Add("produtos", produtos);
                    parametros.Add("produtos_2", produtos_2);

                    parametros.Add("faixa", faixa);
                    parametros.Add("faixa_2", faixa_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
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
        public HttpResponseMessage DashboardEfetividade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/acionamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage AcionamentoDigital(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable rota = JsonConvert.DeserializeObject<DataTable>(form["rota"]);
                DataTable uf = JsonConvert.DeserializeObject<DataTable>(form["uf"]);
                DataTable tipoChamada = JsonConvert.DeserializeObject<DataTable>(form["tipoChamada"]);
                DataTable tipoTelefone = JsonConvert.DeserializeObject<DataTable>(form["tipoTelefone"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];

                string data = form["data"];
                string hora = form["hora"];
                string chkOcorrencia = form["chkOcorrencia"];
                string chkFila = form["chkFila"];
                string chkProduto = form["chkProduto"];
                string chkRota = form["chkRota"];
                string chkUF = form["chkUF"];
                string chkTipoChamada = form["chkTipoChamada"];
                string chkTipoTelefone = form["chkTipoTelefone"];

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("fila", fila);
                    parametros.Add("produto", produto);
                    parametros.Add("rota", rota);
                    parametros.Add("uf", uf);
                    parametros.Add("tipoChamada", tipoChamada);
                    parametros.Add("tipoTelefone", tipoTelefone);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("chkOcorrencia", chkOcorrencia);
                    parametros.Add("chkFila", chkFila);
                    parametros.Add("chkProduto", chkProduto);
                    parametros.Add("chkRota", chkRota);
                    parametros.Add("chkUF", chkUF);
                    parametros.Add("chkTipoChamada", chkTipoChamada);
                    parametros.Add("chkTipoTelefone", chkTipoTelefone);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acionamento", parametros);

                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }


        }

        [Route("dashboard/download")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadExcelDigital(FormDataCollection form)
        {

            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable rota = JsonConvert.DeserializeObject<DataTable>(form["rota"]);
                DataTable uf = JsonConvert.DeserializeObject<DataTable>(form["uf"]);
                DataTable tipoChamada = JsonConvert.DeserializeObject<DataTable>(form["tipoChamada"]);
                DataTable tipoTelefone = JsonConvert.DeserializeObject<DataTable>(form["tipoTelefone"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string chkOcorrencia = form["chkOcorrencia"];
                string chkFila = form["chkFila"];
                string chkProduto = form["chkProduto"];
                string chkRota = form["chkRota"];
                string chkUF = form["chkUF"];
                string chkTipoChamada = form["chkTipoChamada"];
                string chkTipoTelefone = form["chkTipoTelefone"];


                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("fila", fila);
                    parametros.Add("produto", produto);
                    parametros.Add("rota", rota);
                    parametros.Add("uf", uf);
                    parametros.Add("tipoChamada", tipoChamada);
                    parametros.Add("tipoTelefone", tipoTelefone);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("chkOcorrencia", chkOcorrencia);
                    parametros.Add("chkFila", chkFila);
                    parametros.Add("chkProduto", chkProduto);
                    parametros.Add("chkRota", chkRota);
                    parametros.Add("chkUF", chkUF);
                    parametros.Add("chkTipoChamada", chkTipoChamada);
                    parametros.Add("chkTipoTelefone", chkTipoTelefone);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_TIM_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
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
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("fila", fila);
                    parametros.Add("faixa", faixa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/sms")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardSms(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);


                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ws_sms", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/sinergy/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardSinergyHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_sinergy", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/sinergy/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardSinergyProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao_sinergy", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/rajadas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRajadas(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_RELATORIO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_timrajadas_dashboard");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region HUMANO

        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltrosHumano()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
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
        public HttpResponseMessage DashboardHoraHoraHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);
                    parametros.Add("equipes", equipe);
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

        [Route("dashboard/humano/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);
                    parametros.Add("equipes", equipe);
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

        [Route("dashboard/humano/comparativo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardComparativoHumano(FormDataCollection form)
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

                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);

                DataTable empresa_2 = JsonConvert.DeserializeObject<DataTable>(form["empresa_2"]);
                DataTable segmento_2 = JsonConvert.DeserializeObject<DataTable>(form["segmento_2"]);
                DataTable atraso_2 = JsonConvert.DeserializeObject<DataTable>(form["atraso_2"]);
                DataTable produto_2 = JsonConvert.DeserializeObject<DataTable>(form["produto_2"]);



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

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
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

                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);

                    parametros.Add("empresa_2", empresa_2);
                    parametros.Add("segmento_2", segmento_2);
                    parametros.Add("atraso_2", atraso_2);
                    parametros.Add("produto_2", produto_2);
                    

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
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
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable saldo = JsonConvert.DeserializeObject<DataTable>(form["saldo"]);
                DataTable estado = JsonConvert.DeserializeObject<DataTable>(form["estado"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);
                    parametros.Add("saldo", saldo);
                    parametros.Add("estado", estado);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
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
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable faixaAtrasoM1 = JsonConvert.DeserializeObject<DataTable>(form["faixaAtrasoM1"]);
                DataTable statusSegmentacao = JsonConvert.DeserializeObject<DataTable>(form["statusSegmentacao"]);
                DataTable estado = JsonConvert.DeserializeObject<DataTable>(form["estado"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("produto", produto);
                    parametros.Add("faixaAtrasoM1", faixaAtrasoM1);
                    parametros.Add("estado", estado);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
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
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable ocorrenciaFiltro = JsonConvert.DeserializeObject<DataTable>(form["ocorrenciaFiltro"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkSupervisor = form["chkSupervisor"];
                string chkEquipe = form["chkEquipe"];
                string chkEmpresa = form["chkEmpresa"];
                string chkSegmento = form["chkSegmento"];
                string chkAtraso = form["chkAtraso"];
                string chkProduto = form["chkProduto"];

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);
                    parametros.Add("ocorrenciaFiltro", ocorrenciaFiltro);
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);


                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    parametros.Add("chkSupervisor", chkSupervisor);
                    parametros.Add("chkEquipe", chkEquipe);
                    parametros.Add("chkEmpresa", chkEmpresa);
                    parametros.Add("chkSegmento", chkSegmento);
                    parametros.Add("chkAtraso", chkAtraso);
                    parametros.Add("chkProduto", chkProduto);

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
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable ocorrenciaFiltro = JsonConvert.DeserializeObject<DataTable>(form["ocorrenciaFiltro"]);

                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);


                string mes = form["mes"];
                string ano = form["ano"];
                string semana = form["semana"];
                string data = form["data"];
                string hora = form["hora"];
                string ocorrencia = form["ocorrencia"];
                string operador = form["operador"];
                string chkSupervisor = form["chkSupervisor"];
                string chkEquipe = form["chkEquipe"];
                string chkEmpresa = form["chkEmpresa"];
                string chkSegmento = form["chkSegmento"];
                string chkAtraso = form["chkAtraso"];
                string chkProduto = form["chkProduto"];

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);

                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);
                    parametros.Add("ocorrenciaFiltro", ocorrenciaFiltro);

                    parametros.Add("mes", mes);
                    parametros.Add("ano", ano);
                    parametros.Add("semana", semana);
                    parametros.Add("data", data);
                    parametros.Add("hora", hora);
                    parametros.Add("ocorrencia", ocorrencia);
                    parametros.Add("operador", operador);
                    parametros.Add("chkSupervisor", chkSupervisor);
                    parametros.Add("chkEquipe", chkEquipe);
                    parametros.Add("chkEmpresa", chkEmpresa);
                    parametros.Add("chkSegmento", chkSegmento);
                    parametros.Add("chkAtraso", chkAtraso);
                    parametros.Add("chkProduto", chkProduto);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_TIM_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
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
                string hrini = form["hrini"];
                string hrfim = form["hrfim"];
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);
                //DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString(string.Format("yyyy-MM-dd {0}:00", hrini)));
                    parametros.Add("dtfim", dtfim.ToString(string.Format("yyyy-MM-dd {0}:59", hrfim)));
                    parametros.Add("filas", filas);
                    //parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_rec", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("atraso", atraso);
                    parametros.Add("produto", produto);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
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
        public HttpResponseMessage DashboardOcupacaoHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                int horaini = Convert.ToInt16(form["horaini"]);
                int horafim = Convert.ToInt16(form["horafim"]);                
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("horaini", horaini);
                    parametros.Add("horafim", horafim);                    
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipe);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/ocupacaoFila")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardOcupacaoFilaHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("produto", produto);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("fila", fila);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacaoFila", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/downloadClassificacao")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadClassificacaoExcel(FormDataCollection form)
        {

            try
            {                

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                   
                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download_classificacao");


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=CLASSIFICACAO_ANALYTICS_TIM_");

                    new GerarArquivo(Response, resultado);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/downloadCarteira")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DownloadCarteiraExcel(FormDataCollection form)
        {

            try
            {

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download_carteira");


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=DEPARA_CARTEIRAS_ANALYTICS_TIM_");

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
        public HttpResponseMessage DashboardEfetividadeHumano(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable segmento = JsonConvert.DeserializeObject<DataTable>(form["segmento"]);
                DataTable faixaatraso = JsonConvert.DeserializeObject<DataTable>(form["faixaatraso"]);
                DataTable produto = JsonConvert.DeserializeObject<DataTable>(form["produto"]);
                DataTable estado = JsonConvert.DeserializeObject<DataTable>(form["estado"]);
                DataTable equipe = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_HUMANO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("segmento", segmento);
                    parametros.Add("faixaatraso", faixaatraso);
                    parametros.Add("produto", produto);
                    parametros.Add("estado", estado);
                    parametros.Add("equipe", equipe);
                    parametros.Add("supervisor", supervisor);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS AKIVA

        [Route("vendas/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
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

        [Route("vendas/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
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

        [Route("vendas/projecao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasProjecao(FormDataCollection form)
        {
            try
            {
                int compararhojecom = Convert.ToInt32(form["compararhojecom"]);
                int compararmescom = Convert.ToInt32(form["compararmescom"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("compararhojecom", compararhojecom);
                    parametros.Add("compararmescom", compararmescom);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_projecao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/faturamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasFaturamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_faturamento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/backoffice")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasBackoffice(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_backoffice", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/tv")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasTV(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_tv");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/ura")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPromessaSMS(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
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

        [Route("vendas/checkretorno")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CheckSMS(FormDataCollection form)
        {
            try
            {
                string id_chamada = form["id_chamada"];
                bool sms = Convert.ToBoolean(form["sms"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_chamada", id_chamada);
                    parametros.Add("sms", Convert.ToInt16(sms).ToString());

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_retornoChamada", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/checkall")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CheckAll(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_retornoChamadaAll", parametros);

                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/relatorio/venda")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RelatorioVendas(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_relatorioVenda", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/relatorio/bko")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RelatorioBKO(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_relatorioBKO", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/relatorio/ativacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RelatorioAtivacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_relatorioAtivacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS MIGRACAO

        [Route("vendas/migracao/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasMigracaoHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_migracao_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/migracao/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasMigracaoProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_migracao_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/migracao/chamadas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasMigracaoChamadas(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_migracao_chamadas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/migracao/backoffice")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasMigracaoBackoffice(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_migracao_backoffice", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS RECEPTIVO

        [Route("vendas/receptivo/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasReceptivoHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_receptivo_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/receptivo/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasReceptivoProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_receptivo_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/receptivo/chamadas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasReceptivoChamadas(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_receptivo_chamadas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/receptivo/backoffice")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasReceptivoBackoffice(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_receptivo_backoffice", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS TELEVENDAS

        [Route("vendas/televendas/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasTelevendasHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_televendas_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/televendas/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasTelevendasProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_televendas_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/televendas/chamadas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasTelevendasChamadas(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_televendas_chamadas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/televendas/backoffice")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasTelevendasBackoffice(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_televendas_backoffice", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region BACKOFFICE

        [Route("vendas/backoffice/chamadas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasBackofficeChamadas(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_backoffice_chamadas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/backoffice/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasBackofficeProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_backoffice_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/backoffice/portabilidade")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasBackofficePortabilidade(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_backoffice_portabilidade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("vendas/backoffice/rastreio")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasBackofficeRastreio(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_rastreio", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS GERENCIAL

        [Route("vendas/gerencial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasGerencial(FormDataCollection form)
        {
            try
            {
                string camapanha = form["campanha"];
                string procedure = "";

                if (camapanha == "migracao")
                    procedure = "atom_dashboard_migracao_gerencial";
                else if (camapanha == "receptivo")
                    procedure = "atom_dashboard_receptivo_gerencial";
                else if (camapanha == "televendas")
                    procedure = "atom_dashboard_televendas_gerencial";
                else if (camapanha == "tudo")
                    procedure = "atom_dashboard_tudo_gerencial";
                else
                    throw new Exception("Campanha inválida");

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS URA

        [Route("vendas/ura/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasUraHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_ura_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/ura/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasUraProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_ura_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region VENDAS POS FAMILIA

        [Route("vendas/posfamilia/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasPosFamiliaHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_posfamilia_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("vendas/posfamilia/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage VendasPosFamiliaProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TIM_VENDAS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("atom_dashboard_posfamilia_producao", parametros);
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
