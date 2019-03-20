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
                DataTable equipes = JsonConvert.DeserializeObject<DataTable>(form["equipe"]);
                DataTable supervisor = JsonConvert.DeserializeObject<DataTable>(form["supervisor"]);
                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
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

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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

                using (SqlHelper sql = new SqlHelper("CUBO_MARISA"))
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
