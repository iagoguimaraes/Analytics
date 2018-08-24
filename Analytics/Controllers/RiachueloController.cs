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
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario); 
                     
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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);

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
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);

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
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);

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

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);

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

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    
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

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("carteiras", carteira);

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
                DataTable funcionario = JsonConvert.DeserializeObject<DataTable>(form["funcionario"]);
                DataTable ocorrencia = JsonConvert.DeserializeObject<DataTable>(form["ocorrencia"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("funcionario", funcionario);
                    parametros.Add("ocorrencia", ocorrencia);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_pesquisa", parametros);
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
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("equipes", equipes);

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
                DataTable supervisores = JsonConvert.DeserializeObject<DataTable>(form["supervisores"]);
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipes"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("supervisores", supervisores);
                    parametros.Add("equipes", equipes);

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
                DataTable empresas = JsonConvert.DeserializeObject<DataTable>(form["empresas"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable empresas_2 = JsonConvert.DeserializeObject<DataTable>(form["empresas_2"]);
                DataTable carteiras_2 = JsonConvert.DeserializeObject<DataTable>(form["carteiras_2"]);

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
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresas_2", empresas_2);
                    parametros.Add("carteiras_2", carteiras_2);

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
                    procedure = "sp_dashboard_grupo";
                if (form["visao"] == "vencimento")
                    procedure = "sp_dashboard_grupoVencimento";

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
                DataTable grupo = JsonConvert.DeserializeObject<DataTable>(form["grupo"]);

                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("grupo", grupo);


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


                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("empresas", empresas);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_carteira_humano", parametros);
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
