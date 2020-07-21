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
    [RoutePrefix("api/riachuelo")]
    public class RiachueloController : ApiController
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
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable fpd = JsonConvert.DeserializeObject<DataTable>(form["fpd"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable inclusao = JsonConvert.DeserializeObject<DataTable>(form["inclusao"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable score = JsonConvert.DeserializeObject<DataTable>(form["score"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("fpd", fpd);
                    parametros.Add("atraso", atraso);
                    parametros.Add("inclusao", inclusao);
                    parametros.Add("empresa", empresa);
                    parametros.Add("score", score);

                    string procedure = "sp_dashboard_horahora";

                    if (form["conceito"] == "_unique")
                    {
                        procedure = "sp_dashboard_horahora_unique";
                    }
                    else if (form["conceito"] == "_total")
                    {
                        procedure = "sp_dashboard_horahora";
                    }
                    else
                    {
                        Console.WriteLine("parametro de conceito não passado");
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);
                DataTable fpd = JsonConvert.DeserializeObject<DataTable>(form["fpd"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable inclusao = JsonConvert.DeserializeObject<DataTable>(form["inclusao"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable score = JsonConvert.DeserializeObject<DataTable>(form["score"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    parametros.Add("fpd", fpd);
                    parametros.Add("atraso", atraso);
                    parametros.Add("inclusao", inclusao);
                    parametros.Add("empresa", empresa);
                    parametros.Add("score", score);

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
                        Console.WriteLine("parametro de conceito não passado");
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);
                DataTable regiao = JsonConvert.DeserializeObject<DataTable>(form["regiao"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    parametros.Add("regiao", regiao);
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("empresa", empresa);

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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);
                DataTable faixaatraso = JsonConvert.DeserializeObject<DataTable>(form["faixaatraso"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    parametros.Add("faixaatraso", faixaatraso);
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade", parametros);
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

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
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

        [Route("dashboard/gerencial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardGerencial(FormDataCollection form)
        {
            try
            {
                DateTime ano = Convert.ToDateTime(form["dtini"]);
                DateTime mesIni = Convert.ToDateTime(form["dtini"]);
                DateTime mesFim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", Convert.ToInt16(ano.ToString("yyyy")));
                    parametros.Add("mesIni", Convert.ToInt16(mesIni.ToString("MM")));
                    parametros.Add("mesFim", Convert.ToInt16(mesFim.ToString("MM")));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_gerencial", parametros);
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
        public HttpResponseMessage DashboardBaseAtivaDigital(FormDataCollection form)
        {
            try
            {
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable segmentacao = JsonConvert.DeserializeObject<DataTable>(form["segmentacao"]);
                DataTable tiposegmentacao = JsonConvert.DeserializeObject<DataTable>(form["tiposegmentacao"]);
                DateTime data = Convert.ToDateTime(form["data"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("data", data);
                    parametros.Add("carteiras", carteira);
                    parametros.Add("tiposegmentacao", tiposegmentacao);
                    parametros.Add("segmentacao", segmentacao);
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/paggerencial")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagGerencial(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_paggerencial");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/negociador")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardNegociador(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_negociador", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/multicanaldigital")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardMultiCanalDigital(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_mktzap_digital", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/pesquisa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPesquisa(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable filas = JsonConvert.DeserializeObject<DataTable>(form["filas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("filas", filas);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pesquisa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/efetividadeperfil")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPerfil(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_efetividade_perfil", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/projecao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Projecao(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("carteiras", carteiras);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_projecao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/projecao/cadmeta")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ProjecaoCadMeta(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                double meta_pl = Convert.ToDouble(form["meta_pl"].ToString().Replace(".", ""));
                double meta_bandeira = Convert.ToDouble(form["meta_bandeira"].ToString().Replace(".", ""));
                double meta_saque = Convert.ToDouble(form["meta_saque"].ToString().Replace(".", ""));
                double meta_emprestimo = Convert.ToDouble(form["meta_emprestimo"].ToString().Replace(".", ""));


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("meta_pl", meta_pl);
                    parametros.Add("meta_bandeira", meta_bandeira);
                    parametros.Add("meta_saque", meta_saque);
                    parametros.Add("meta_emprestimo", meta_emprestimo);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_projecao_cadmeta", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/pf/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage PFHoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pf_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/pf/cadmailing")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CadMailing(FormDataCollection form)
        {
            try
            {
                DataTable mailingPf = JsonConvert.DeserializeObject<DataTable>(form.ReadAsNameValueCollection().Keys[0].ToString());

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("mailingPf", mailingPf);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_fatoMailingPF", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/pf/pesquisa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPesquisaPF(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pf_pesquisa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/baserolagem")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBaseRolagem(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baserolagem");
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
        public HttpResponseMessage DashboardEnvioSms(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_ws_sms", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/portalnegocia")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPortalNegocia(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable servidores = JsonConvert.DeserializeObject<DataTable>(form["servidores"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable id_class_carteira = JsonConvert.DeserializeObject<DataTable>(form["id_class_carteira"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("servidores", servidores);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("id_class_carteira", id_class_carteira);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_portalnegocia", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/enriquecimento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardEnriquecimento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable regiao = JsonConvert.DeserializeObject<DataTable>(form["regiao"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("regiao", regiao);
                    parametros.Add("empresa", empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_enriquecimento", parametros);
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable score = JsonConvert.DeserializeObject<DataTable>(form["score"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("score", score);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_lote", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/erroboleto")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPortalErroBoleto(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_portal_erro_boleto", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/checkboleto")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage CheckBoleto(FormDataCollection form)
        {
            try
            {
                string id_status = form["id_status"];
                bool tratado = Convert.ToBoolean(form["tratado"]);
                int id_empresa = Convert.ToInt32(form["id_empresa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_status", id_status);
                    parametros.Add("tratado", Convert.ToInt16(tratado).ToString());
                    parametros.Add("id_empresa", id_empresa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_erroBoleto", parametros);
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
        public HttpResponseMessage DashboardHumanoFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_filtros");
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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable saldo = JsonConvert.DeserializeObject<DataTable>(form["saldo"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);
                DataTable origemPromessa = JsonConvert.DeserializeObject<DataTable>(form["origemPromessa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("saldo", saldo);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("save", save);
                    parametros.Add("origemPromessa", origemPromessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_horahora", parametros);
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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable saldo = JsonConvert.DeserializeObject<DataTable>(form["saldo"]);
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);
                DataTable origemPromessa = JsonConvert.DeserializeObject<DataTable>(form["origemPromessa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("saldo", saldo);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("save", save);
                    parametros.Add("origemPromessa", origemPromessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_producao", parametros);
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


                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable carteira = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable atraso = JsonConvert.DeserializeObject<DataTable>(form["atraso"]);
                DataTable saldo = JsonConvert.DeserializeObject<DataTable>(form["saldo"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);


                DataTable empresa_2 = JsonConvert.DeserializeObject<DataTable>(form["empresa_2"]);
                DataTable carteira_2 = JsonConvert.DeserializeObject<DataTable>(form["carteira_2"]);
                DataTable supervisor_2 = JsonConvert.DeserializeObject<DataTable>(form["supervisor_2"]);
                DataTable bandeira_2 = JsonConvert.DeserializeObject<DataTable>(form["bandeira_2"]);
                DataTable atraso_2 = JsonConvert.DeserializeObject<DataTable>(form["atraso_2"]);
                DataTable saldo_2 = JsonConvert.DeserializeObject<DataTable>(form["saldo_2"]);
                DataTable save_2 = JsonConvert.DeserializeObject<DataTable>(form["save_2"]);

                string procedure = "sp_dashboard_humano_comparativo_hora";

                if (form["visao"] == "hora")
                    procedure = "sp_dashboard_humano_comparativo_hora";
                if (form["visao"] == "dia")
                    procedure = "sp_dashboard_humano_comparativo_dia";
                if (form["visao"] == "dia_semana")
                    procedure = "sp_dashboard_humano_comparativo_dia_semana";
                if (form["visao"] == "semana")
                    procedure = "sp_dashboard_humano_comparativo_semana";
                if (form["visao"] == "mes")
                    procedure = "sp_dashboard_humano_comparativo_mes";

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
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
                    parametros.Add("carteira", carteira);
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("atraso", atraso);
                    parametros.Add("saldo", saldo);
                    parametros.Add("save", save);


                    parametros.Add("empresa_2", empresa_2);
                    parametros.Add("carteira_2", carteira_2);
                    parametros.Add("supervisor_2", supervisor_2);
                    parametros.Add("bandeira_2", bandeira_2);
                    parametros.Add("atraso_2", atraso_2);
                    parametros.Add("saldo_2", saldo_2);
                    parametros.Add("save_2", save_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/grupo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardGrupo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable grupo = JsonConvert.DeserializeObject<DataTable>(form["grupo"]);

                string procedure = "sp_dashboard_grupo";

                if (form["visao"] == "andamento")
                    procedure = "sp_dashboard_mala";
                if (form["visao"] == "vencimento")
                    procedure = "sp_dashboard_malaVencimento";

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("grupo", grupo);


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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteira"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable faixaAtraso = JsonConvert.DeserializeObject<DataTable>(form["faixaAtraso"]);
                DataTable faixaSaldo = JsonConvert.DeserializeObject<DataTable>(form["faixaSaldo"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("faixaAtraso", faixaAtraso);
                    parametros.Add("faixaSaldo", faixaSaldo);
                    parametros.Add("save", save);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_baseativa", parametros);
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
        public HttpResponseMessage DashboardHumanoCarteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable bandeiras = JsonConvert.DeserializeObject<DataTable>(form["bandeiras"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresas", empresas);
                    parametros.Add("bandeiras", bandeiras);
                    parametros.Add("faixas", faixas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira_humano", parametros);
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
                string hrini = form["hrini"];
                string hrfim = form["hrfim"];
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString(string.Format("yyyy-MM-dd {0}:00", hrini)));
                    parametros.Add("dtfim", dtfim.ToString(string.Format("yyyy-MM-dd {0}:59", hrfim)));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_rec", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/recebimento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoRecebimento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_recebimento", parametros);
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
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("supervisor", supervisor);
                    parametros.Add("equipe", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_ocupacao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/cadmeta")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ProjecaoCadMetaHumano(FormDataCollection form)
        {
            try
            {
                int ano = Convert.ToInt32(form["ano"]);
                int mes = Convert.ToInt32(form["mes"]);
                int meta_menor30 = Convert.ToInt32(form["meta_menor30"].ToString().Replace(".", ""));
                int meta_31a90 = Convert.ToInt32(form["meta_31a90"].ToString().Replace(".", ""));
                int meta_91a180 = Convert.ToInt32(form["meta_91a180"].ToString().Replace(".", ""));
                int meta_181a360 = Convert.ToInt32(form["meta_181a360"].ToString().Replace(".", ""));
                int meta_361a720 = Convert.ToInt32(form["meta_361a720"].ToString().Replace(".", ""));
                int meta_721a1080 = Convert.ToInt32(form["meta_721a1080"].ToString().Replace(".", ""));
                int meta_1081a9999 = Convert.ToInt32(form["meta_1081a9999"].ToString().Replace(".", ""));

                int meta_menor30_promessa = Convert.ToInt32(form["meta_menor30_promessa"].ToString().Replace(".", ""));
                int meta_31a90_promessa = Convert.ToInt32(form["meta_31a90_promessa"].ToString().Replace(".", ""));
                int meta_91a180_promessa = Convert.ToInt32(form["meta_91a180_promessa"].ToString().Replace(".", ""));
                int meta_181a360_promessa = Convert.ToInt32(form["meta_181a360_promessa"].ToString().Replace(".", ""));
                int meta_361a720_promessa = Convert.ToInt32(form["meta_361a720_promessa"].ToString().Replace(".", ""));
                int meta_721a1080_promessa = Convert.ToInt32(form["meta_721a1080_promessa"].ToString().Replace(".", ""));
                int meta_1081a9999_promessa = Convert.ToInt32(form["meta_1081a9999_promessa"].ToString().Replace(".", ""));


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("ano", ano);
                    parametros.Add("mes", mes);
                    parametros.Add("meta_menor30", meta_menor30);
                    parametros.Add("meta_31a90", meta_31a90);
                    parametros.Add("meta_91a180", meta_91a180);
                    parametros.Add("meta_181a360", meta_181a360);
                    parametros.Add("meta_361a720", meta_361a720);
                    parametros.Add("meta_721a1080", meta_721a1080);
                    parametros.Add("meta_1081a9999", meta_1081a9999);

                    parametros.Add("meta_menor30_promessa", meta_menor30_promessa);
                    parametros.Add("meta_31a90_promessa", meta_31a90_promessa);
                    parametros.Add("meta_91a180_promessa", meta_91a180_promessa);
                    parametros.Add("meta_181a360_promessa", meta_181a360_promessa);
                    parametros.Add("meta_361a720_promessa", meta_361a720_promessa);
                    parametros.Add("meta_721a1080_promessa", meta_721a1080_promessa);
                    parametros.Add("meta_1081a9999_promessa", meta_1081a9999_promessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_cadmeta", parametros);
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
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("faixas", faixas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_metas", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/humano/acaomassiva")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoMaassivo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("faixas", faixas);
                    parametros.Add("save", save);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_acaomassiva", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/baserolagem")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoBaseRolagem(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_baserolagem");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/humano/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoPagamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);
                DataTable regra_pagamento = JsonConvert.DeserializeObject<DataTable>(form["regra_pagamento"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("faixas", faixas);
                    parametros.Add("save", save);
                    parametros.Add("origem", origem);
                    parametros.Add("plano", plano);
                    parametros.Add("regra_pagamento", regra_pagamento);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_pagamento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        #endregion

        #region COBRANCA

        [Route("dashboard/humano/filtrosRiachuelo")] // filtros cliente - 31 a 90
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoFiltros31a90()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_filtros_31a90");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/CobrancaRiachuelo/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoHoraHoraCliente(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                //DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                //DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                //DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    //parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    //parametros.Add("supervisores", supervisores);
                    //parametros.Add("equipes", equipes);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_horahora_31a90", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/CobrancaRiachuelo/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoProducaoCliente(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_producao_31a90", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/CobrancaRiachuelo/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHumanoCarteiraCliente(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_humano_carteira_31a90", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/CobrancaRiachuelo/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagamentoCliente(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento_humano_31a90", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region 31 a 90

        [Route("31a90/filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Filtros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
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

        [Route("31a90/baseativa")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90BaseAtiva(FormDataCollection form)
        {
            try
            {
                DateTime data = Convert.ToDateTime(form["data"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baseativa", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90HoraHora(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable bandeiras = JsonConvert.DeserializeObject<DataTable>(form["bandeiras"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable origemPromessa = JsonConvert.DeserializeObject<DataTable>(form["origemPromessa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("bandeiras", bandeiras);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("origemPromessa", origemPromessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Producao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable bandeiras = JsonConvert.DeserializeObject<DataTable>(form["bandeiras"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);
                DataTable origemPromessa = JsonConvert.DeserializeObject<DataTable>(form["origemPromessa"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("bandeiras", bandeiras);
                    parametros.Add("atrasos", atrasos);
                    parametros.Add("origemPromessa", origemPromessa);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Carteira(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable bandeiras = JsonConvert.DeserializeObject<DataTable>(form["bandeiras"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("bandeiras", bandeiras);
                    parametros.Add("atrasos", atrasos);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/comparativo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Comparativo(FormDataCollection form)
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


                DataTable bandeiras = JsonConvert.DeserializeObject<DataTable>(form["bandeiras"]);
                DataTable atrasos = JsonConvert.DeserializeObject<DataTable>(form["atrasos"]);

                DataTable bandeiras_2 = JsonConvert.DeserializeObject<DataTable>(form["bandeiras_2"]);
                DataTable atrasos_2 = JsonConvert.DeserializeObject<DataTable>(form["atrasos_2"]);

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

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
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


                    parametros.Add("bandeiras", bandeiras);
                    parametros.Add("atrasos", atrasos);

                    parametros.Add("bandeiras_2", bandeiras_2);
                    parametros.Add("atrasos_2", atrasos_2);

                    DataSet resultado = sql.ExecuteProcedureDataSet(procedure, parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/baserolagem")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90BaseRolagem(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_baserolagem");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/receptivo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Receptivo(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                string hrini = form["hrini"];
                string hrfim = form["hrfim"];
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString(string.Format("yyyy-MM-dd {0}:00", hrini)));
                    parametros.Add("dtfim", dtfim.ToString(string.Format("yyyy-MM-dd {0}:59", hrfim)));
                    parametros.Add("carteiras", carteiras);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_receptivo", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("31a90/ocupacao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Ocupacao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
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

        [Route("31a90/pagamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard31a90Pagamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable ranking = JsonConvert.DeserializeObject<DataTable>(form["ranking"]);
                DataTable empresa = JsonConvert.DeserializeObject<DataTable>(form["empresa"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable bandeira = JsonConvert.DeserializeObject<DataTable>(form["bandeira"]);
                DataTable faixas = JsonConvert.DeserializeObject<DataTable>(form["faixas"]);
                DataTable save = JsonConvert.DeserializeObject<DataTable>(form["save"]);
                DataTable origem = JsonConvert.DeserializeObject<DataTable>(form["origem"]);
                DataTable plano = JsonConvert.DeserializeObject<DataTable>(form["plano"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO_3190"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("ranking", ranking);
                    parametros.Add("empresa", empresa);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("bandeira", bandeira);
                    parametros.Add("faixas", faixas);
                    parametros.Add("save", save);
                    parametros.Add("origem", origem);
                    parametros.Add("plano", plano);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
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
