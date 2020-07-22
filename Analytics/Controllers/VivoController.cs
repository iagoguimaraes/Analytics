﻿using Newtonsoft.Json;
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
    [RoutePrefix("api/vivo")]
    public class VivoController : ApiController
    {
        [Route("dashboard/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
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
                DateTime data = Convert.ToDateTime(form["data"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

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
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

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
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
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
                DataTable campanha = JsonConvert.DeserializeObject<DataTable>(form["campanha"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanha", campanha);
                    parametros.Add("segmentacao", segmentacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ocupacao", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_HUMANO_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
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
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable tipobilling = JsonConvert.DeserializeObject<DataTable>(form["tipobilling"]);
                DataTable aging = JsonConvert.DeserializeObject<DataTable>(form["aging"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable campanhaNectar = JsonConvert.DeserializeObject<DataTable>(form["campanhaNectar"]);
                DataTable segmentacaoNectar = JsonConvert.DeserializeObject<DataTable>(form["segmentacaoNectar"]);
                DataTable faixaatraso = JsonConvert.DeserializeObject<DataTable>(form["faixaatraso"]);
                DataTable faixavalor = JsonConvert.DeserializeObject<DataTable>(form["faixavalor"]);
                DataTable estado = JsonConvert.DeserializeObject<DataTable>(form["estado"]);
                DataTable statusSegmentacao = JsonConvert.DeserializeObject<DataTable>(form["statusSegmentacao"]);
                DataTable situacao = JsonConvert.DeserializeObject<DataTable>(form["situacao"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_HUMANO_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);
                    parametros.Add("tipobilling", tipobilling);
                    parametros.Add("aging", aging);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("campanhaNectar", campanhaNectar);
                    parametros.Add("segmentacaoNectar", segmentacaoNectar);
                    parametros.Add("faixaatraso", faixaatraso);
                    parametros.Add("faixavalor", faixavalor);
                    parametros.Add("estado", estado);
                    parametros.Add("statusSegmentacao", statusSegmentacao);
                    parametros.Add("situacao", situacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
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
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);
                DataTable segmentacoes_2 = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes_2"]);
                DataTable campanhas_2 = JsonConvert.DeserializeObject<DataTable>(form["campanhas_2"]);

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

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("dtini_2", dtini_2.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim_2", dtfim_2.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("segmentacoes_2", segmentacoes_2);
                    parametros.Add("campanhas_2", campanhas_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/navegacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardNavegacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_navegacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/respostasms")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRespostaSMS(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("DB_ROBO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd 23:59:59"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_respostasms", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/retornosms")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRetornoSMS(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("DB_ROBO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd 23:59:59"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_retornosms", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("relatorio/navegacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RelatorioNavegacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_relatorio_navegacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/lote")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardLote(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable produtos = JsonConvert.DeserializeObject<DataTable>(form["produtos"]);
                int situacao = Convert.ToInt32(form["situacao"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_HUMANO_NEW"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);
                    parametros.Add("situacao", situacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_lote", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/ad3d")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAD3D(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ad3d", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/convergencia")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardConvergencia()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_convergencia");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/score")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScore(FormDataCollection form)
        {
            try
            {
                DataTable piloto = JsonConvert.DeserializeObject<DataTable>(form["piloto"]);

                using (SqlHelper sql = new SqlHelper("DB_RELATORIO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("piloto", piloto);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_score", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/score2")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScore2(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_RELATORIO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_score2", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/score/filtros")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScoreFiltros(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_SCORE"))
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

        [Route("dashboard/score/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScoreHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["data"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_SCORE"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", dtini.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/score/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScoreProducao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable campanhas = JsonConvert.DeserializeObject<DataTable>(form["campanhas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_SCORE"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanhas", campanhas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/score/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardScoreCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO_SCORE"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/renitencia")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardRenitencia(FormDataCollection form)
        {
            try
            {
                DateTime data = Convert.ToDateTime(form["data"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_renitencia", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/acordo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAcordo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_promessa_escob", parametros);
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
                DataTable discador = JsonConvert.DeserializeObject<DataTable>(form["discador"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("discador", discador);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/checkacordo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CheckAcordo(FormDataCollection form)
        {
            try
            {
                string id_chamada = form["id_chamada"];
                bool marcado = Convert.ToBoolean(form["marcado"]);
                int id_segmentacao = Convert.ToInt32(form["id_segmentacao"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_chamada", id_chamada);
                    parametros.Add("marcado", Convert.ToInt16(marcado).ToString());
                    parametros.Add("id_segmentacao", id_segmentacao);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_promessa", parametros);
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
        public HttpResponseMessage DashboardHoraHoraCallflex(FormDataCollection form)
        {
            try
            {
                DateTime data = Convert.ToDateTime(form["data"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("filas", filas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora_callflex", parametros);
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
        public HttpResponseMessage DashboardProducaoCallflex(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable segmentacoes = JsonConvert.DeserializeObject<DataTable>(form["segmentacoes"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("filas", filas);

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