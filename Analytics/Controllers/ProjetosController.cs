using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/projetos")]
    public class ProjetosController : ApiController
    {
        [Route("variaveis")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ObterVariaveis()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("prjt_sel_variaveis");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("variaveis/inserir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirVariavel(FormDataCollection form)
        {
            try
            {
                string tabela = form["tabela"];
                string descricao = form["descricao"];
                string query = "";

                string[] tabelas = new string[] { "RESPONSAVEL", "SOLICITANTE", "DEPARTAMENTO", "CATEGORIA" };

                if (tabelas.Contains(tabela))
                    query = string.Format("insert into PRJT_{0}({0},ativo) values (@descricao,1)", tabela);
                else
                    throw new Exception("Tabela inválida");

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@descricao", descricao);

                    sql.ExecuteQueryDataTable(query, parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("variaveis/excluir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ExcluirVariavel(FormDataCollection form)
        {
            try
            {
                string tabela = form["tabela"];
                int id = Convert.ToInt32(form["id"]);
                string query = "";

                string[] tabelas = new string[] { "RESPONSAVEL", "SOLICITANTE", "DEPARTAMENTO", "CATEGORIA" };

                if (tabelas.Contains(tabela))
                    query = string.Format("update PRJT_{0} set ativo = 0 where id_{0} = @id", tabela);
                else
                    throw new Exception("Tabela inválida");

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@id", id);

                    sql.ExecuteQueryDataTable(query, parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("consultar")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ConsultarProjetos(FormDataCollection form)
        {
            try
            {
                DataTable status = JsonConvert.DeserializeObject<DataTable>(form["status"]);
                DataTable responsaveis = JsonConvert.DeserializeObject<DataTable>(form["responsaveis"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@status", status);
                    parameters.Add("@responsaveis", responsaveis);

                    DataSet resultado = sql.ExecuteProcedureDataSet("prjt_sel_projeto", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("inserir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirProjeto(FormDataCollection form)
        {
            try
            {
                string nome = form["nome"];
                string objetivo = form["objetivo"];
                DataTable id_responsavel = JsonConvert.DeserializeObject<DataTable>(form["id_responsavel"]);
                int id_solicitante = Convert.ToInt32(form["id_solicitante"]);
                int id_departamento = Convert.ToInt32(form["id_departamento"]);
                int id_categoria = Convert.ToInt32(form["id_categoria"]);
                int id_prioridade = Convert.ToInt32(form["id_prioridade"]);
                int id_porte = Convert.ToInt32(form["id_porte"]);
                DateTime prazo = Convert.ToDateTime(form["prazo"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@nome", nome);
                    parameters.Add("@objetivo", objetivo);
                    parameters.Add("@id_responsavel", id_responsavel);
                    parameters.Add("@id_solicitante", id_solicitante);
                    parameters.Add("@id_departamento", id_departamento);
                    parameters.Add("@id_categoria", id_categoria);
                    parameters.Add("@id_prioridade", id_prioridade);
                    parameters.Add("@id_porte", id_porte);
                    parameters.Add("@prazo", prazo.Year == 1? null : prazo.ToString("yyyy-MM-dd"));

                    sql.ExecuteProcedureDataTable("prjt_ins_projeto", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("editar")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage EditarProjeto(FormDataCollection form)
        {
            try
            {
                int id_projeto = Convert.ToInt32(form["id_projeto"]);
                string nome = form["nome"];
                string objetivo = form["objetivo"];
                int id_status = Convert.ToInt32(form["id_status"]);
                DataTable id_responsavel = JsonConvert.DeserializeObject<DataTable>(form["id_responsavel"]);
                int id_solicitante = Convert.ToInt32(form["id_solicitante"]);
                int id_departamento = Convert.ToInt32(form["id_departamento"]);
                int id_categoria = Convert.ToInt32(form["id_categoria"]);
                int id_prioridade = Convert.ToInt32(form["id_prioridade"]);
                int id_porte = Convert.ToInt32(form["id_porte"]);
                DateTime prazo = Convert.ToDateTime(string.IsNullOrEmpty(form["prazo"])?null: form["prazo"]);
                DateTime dtini = Convert.ToDateTime(string.IsNullOrEmpty(form["dtini"]) ? null : form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(string.IsNullOrEmpty(form["dtfim"]) ? null : form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_projeto", id_projeto);
                    parameters.Add("@nome", nome);
                    parameters.Add("@objetivo", objetivo);
                    parameters.Add("@id_status", id_status);
                    parameters.Add("@id_responsavel", id_responsavel);
                    parameters.Add("@id_solicitante", id_solicitante);
                    parameters.Add("@id_departamento", id_departamento);
                    parameters.Add("@id_categoria", id_categoria);
                    parameters.Add("@id_prioridade", id_prioridade);
                    parameters.Add("@id_porte", id_porte);
                    parameters.Add("@prazo", prazo.Year == 1 ? null : prazo.ToString("yyyy-MM-dd"));
                    parameters.Add("@dtini", dtini.Year == 1 ? null : dtini.ToString("yyyy-MM-dd"));
                    parameters.Add("@dtfim", dtfim.Year == 1 ? null : dtfim.ToString("yyyy-MM-dd"));

                    sql.ExecuteProcedureDataTable("prjt_upd_projeto", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("kpi/editar")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage EditarKPIProjeto(FormDataCollection form)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@id_projeto", Convert.ToInt32(form["id_projeto"]));

                if (!string.IsNullOrEmpty(form["esforco"]))
                    parameters.Add("@esforco", Convert.ToDouble(form["esforco"]));

                if (!string.IsNullOrEmpty(form["custo_setup"]))
                    parameters.Add("@custo_setup", Convert.ToDouble(form["custo_setup"]));

                if (!string.IsNullOrEmpty(form["custo_mensal"]))
                    parameters.Add("@custo_mensal", Convert.ToDouble(form["custo_mensal"]));

                if (!string.IsNullOrEmpty(form["kpi_quantitativo"]))
                    parameters.Add("@kpi_quantitativo", form["kpi_quantitativo"]);

                if (!string.IsNullOrEmpty(form["kpi_qualitativo"]))
                    parameters.Add("@kpi_qualitativo", form["kpi_qualitativo"]);

                if (!string.IsNullOrEmpty(form["kpi_afericao"]))
                    parameters.Add("@kpi_afericao", form["kpi_afericao"]);


                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    sql.ExecuteProcedureDataTable("prjt_upd_kpiprojeto", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("excluir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ExcluirProjeto(FormDataCollection form)
        {
            try
            {
                int id_projeto = Convert.ToInt32(form["id_projeto"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_projeto", id_projeto);

                    sql.ExecuteProcedureDataTable("prjt_del_projeto", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("etapas/inserir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirEtapa(FormDataCollection form)
        {
            try
            {
                int id_projeto = Convert.ToInt32(form["id_projeto"]);
                string descricao = form["descricao"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_projeto", id_projeto);
                    parameters.Add("@descricao", descricao);

                    sql.ExecuteProcedureDataTable("prjt_ins_etapa", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("etapas/excluir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ExcluirEtapa(FormDataCollection form)
        {
            try
            {
                int id_etapa = Convert.ToInt32(form["id_etapa"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_etapa", id_etapa);

                    sql.ExecuteProcedureDataTable("prjt_del_etapa", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("etapas/concluir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ConcluirEtapa(FormDataCollection form)
        {
            try
            {
                int id_etapa = Convert.ToInt32(form["id_etapa"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_etapa", id_etapa);
                    parameters.Add("@concluido", 1);

                    sql.ExecuteProcedureDataTable("prjt_upd_etapa", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("etapas/reativar")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ReativarEtapa(FormDataCollection form)
        {
            try
            {
                int id_etapa = Convert.ToInt32(form["id_etapa"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_etapa", id_etapa);
                    parameters.Add("@concluido", 0);

                    sql.ExecuteProcedureDataTable("prjt_upd_etapa", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("comentarios/inserir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirComentario(FormDataCollection form)
        {
            try
            {
                int id_projeto = Convert.ToInt32(form["id_projeto"]);
                string comentario = form["comentario"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_projeto", id_projeto);
                    parameters.Add("@comentario", comentario);

                    sql.ExecuteProcedureDataTable("prjt_ins_comentario", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("comentarios/excluir")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ExcluirComentario(FormDataCollection form)
        {
            try
            {
                int id_comentario = Convert.ToInt32(form["id_comentario"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("@id_comentario", id_comentario);

                    sql.ExecuteProcedureDataTable("prjt_del_comentario", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Dashboard(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parameters.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("prjt_dashboard", parameters);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("gantt")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardGantt(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parameters.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    DataSet resultado = sql.ExecuteProcedureDataSet("prjt_gantt2", parameters);
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
