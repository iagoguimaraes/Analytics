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
    [RoutePrefix("api/marisa")]
    public class MarisaController : ApiController
    {
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

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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

        [Route("dashboard/humano/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_filtros");
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
        public HttpResponseMessage DashboardHumanoHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("atrasos", produtos);
                    parametros.Add("faixas", atrasos);
                    parametros.Add("supervisores", supervisor);
                    parametros.Add("equipes", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_horahora", parametros);
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
        public HttpResponseMessage DashboardHumanoProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("atrasos", produtos);
                    parametros.Add("faixas", atrasos);
                    parametros.Add("supervisores", supervisor);
                    parametros.Add("equipes", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_producao", parametros);
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
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);
                DataTable classe = JsonConvert.DeserializeObject<DataTable>(form["classe"]);

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
                string chkFaixa = form["chkFaixa"];
                string chkClasse = form["chkClasse"];

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixa", faixa);
                    parametros.Add("classe", classe);

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
                    parametros.Add("chkFaixa", chkFaixa);
                    parametros.Add("chkClasse", chkClasse);

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
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);
                DataTable classe = JsonConvert.DeserializeObject<DataTable>(form["classe"]);

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
                string chkFaixa = form["chkFaixa"];
                string chkClasse = form["chkClasse"];

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixa", faixa);
                    parametros.Add("classe", classe);

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
                    parametros.Add("chkFaixa", chkFaixa);
                    parametros.Add("chkClasse", chkClasse);

                    DataTable resultado = sql.ExecuteProcedureDataTable("sp_dashboard_download", parametros);


                    HttpResponse Response = HttpContext.Current.Response;

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.ContentType = "application/csv";
                    Response.AddHeader("Content-Disposition", "attachment;filename=ACIONAMENTOS_ANALYTICS_MARISA_");

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
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString(string.Format("yyyy-MM-dd {0}:00", hrini)));
                    parametros.Add("dtfim", dtfim.ToString(string.Format("yyyy-MM-dd {0}:59", hrfim)));
                    parametros.Add("faixas", faixas);
                    parametros.Add("atrasos", atrasos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_rec", parametros);
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
        public HttpResponseMessage DashboardHumanoOcupacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/cadmetas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CadMetaHumano(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int meta_prepdd = Convert.ToInt32(form["meta_prepdd"].ToString().Replace(".", ""));
                int meta_pdd = Convert.ToInt32(form["meta_pdd"].ToString().Replace(".", ""));
                int meta_fase1 = Convert.ToInt32(form["meta_fase1"].ToString().Replace(".", ""));
                int meta_fase2 = Convert.ToInt32(form["meta_fase2"].ToString().Replace(".", ""));
                int meta_prepdd_promessa = Convert.ToInt32(form["meta_prepdd_promessa"].ToString().Replace(".", ""));
                int meta_pdd_promessa = Convert.ToInt32(form["meta_pdd_promessa"].ToString().Replace(".", ""));
                int meta_fase1_promessa = Convert.ToInt32(form["meta_fase1_promessa"].ToString().Replace(".", ""));
                int meta_fase2_promessa = Convert.ToInt32(form["meta_fase2_promessa"].ToString().Replace(".", ""));


                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("meta_prepdd", meta_prepdd);
                    parametros.Add("meta_pdd", meta_pdd);
                    parametros.Add("meta_fase1", meta_fase1);
                    parametros.Add("meta_fase2", meta_fase2);
                    parametros.Add("meta_prepdd_promessa", meta_prepdd_promessa);
                    parametros.Add("meta_pdd_promessa", meta_pdd_promessa);
                    parametros.Add("meta_fase1_promessa", meta_fase1_promessa);
                    parametros.Add("meta_fase2_promessa", meta_fase2_promessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_ins_cadmeta", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/metas")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoPlanejamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixas", produtos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_humano_dashboard_metas", parametros);
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

                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable faixa = JsonConvert.DeserializeObject<DataTable>(form["faixa"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                DataTable atraso_2 = JsonConvert.DeserializeObject<DataTable>(form["atraso_2"]);
                DataTable faixa_2 = JsonConvert.DeserializeObject<DataTable>(form["faixa_2"]);
                DataTable supervisor_2 = JsonConvert.DeserializeObject<DataTable>(form["supervisor_2"]);


                string procedure = "sp_humano_dashboard_comparativo_hora";

                if (form["visao"] == "hora")
                    procedure = "sp_humano_dashboard_comparativo_hora";
                if (form["visao"] == "dia")
                    procedure = "sp_humano_dashboard_comparativo_dia";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_humano_dashboard_comparativo_dia_semana";
                if (form["visao"] == "semana")
                    procedure = "sp_humano_dashboard_comparativo_semana";
                if (form["visao"] == "mes")
                    procedure = "sp_humano_dashboard_comparativo_mes";

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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

                    parametros.Add("atraso", atraso);
                    parametros.Add("faixa", faixa);
                    parametros.Add("supervisor", supervisor);

                    parametros.Add("atraso_2", atraso_2);
                    parametros.Add("faixa_2", faixa_2);
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

        [Route("dashboard/callflex/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHoraCallFlex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
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

        [Route("dashboard/callflex/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducaoCallFlex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    string procedure = "sp_dashboard_producao";

                    if (form["conceito"] == "_unique")
                    {
                        procedure = "sp_dashboard_producao_unique";
                    }
                    else if (form["conceito"] == "_total")
                    {
                        procedure = "sp_dashboard_producao";
                    }
                    else
                    {
                        Console.WriteLine ("parametro de conceito não passado");
                    }


                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
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
        public HttpResponseMessage DashboardDigitalFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
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

        [Route("dashboard/digital/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardDigitalCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("atraso", atraso);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
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
        public HttpResponseMessage DashboardDigitalBaseAtiva(FormDataCollection form)
        {
            try
            {
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("atraso", atraso);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/digital/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardDigitalPagamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA_DIGITAL"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("atraso", atraso);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
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
