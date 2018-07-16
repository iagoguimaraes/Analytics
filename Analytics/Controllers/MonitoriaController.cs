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
    [RoutePrefix("api/monitoria")]
    public class MonitoriaController : ApiController
    {

        [Route("consultar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage ConsultarDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string grupos = form["grupos"];
                string empresas = form["empresas"];
                string carteiras = form["carteiras"];
                string ocorrencias = form["ocorrencias"];
                string usuarios = form["usuarios"];

                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(string.Concat(dtfim, " 23:59:59"));

                DataTable _grupos = JsonConvert.DeserializeObject<DataTable>(grupos);
                DataTable _empresas = JsonConvert.DeserializeObject<DataTable>(empresas);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);
                DataTable _ocorrencias = JsonConvert.DeserializeObject<DataTable>(ocorrencias);
                DataTable _usuarios = JsonConvert.DeserializeObject<DataTable>(usuarios);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("dtini", _dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", _dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("grupos", _grupos);
                    parametros.Add("empresas", _empresas);
                    parametros.Add("carteiras", _carteiras);
                    parametros.Add("ocorrencias", _ocorrencias);
                    parametros.Add("usuarios", _usuarios);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("opcoes")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage OpcoesDiarioBordo()
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_opcoes_monitoria", parametros);
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
        public HttpResponseMessage InserirDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                string data = form["data"];
                string hora = form["hora"];
                int id_grupo = Convert.ToInt32(form["grupo"]);
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                int id_campanha = Convert.ToInt32(form["campanha"]);
                string descricao = form["descricao"];
                string cpf = form["cpf"];
                string tel = form["tel"];
                string persona = form["persona"];
                string link = form["link"];


                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", _data);
                    parametros.Add("id_grupo", id_grupo);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_campanha", id_campanha);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("descricao", descricao);
                    parametros.Add("cpf", cpf);
                    parametros.Add("tel", tel);
                    parametros.Add("persona", persona);
                    parametros.Add("link", link);


                    sql.ExecuteProcedureDataSet("sp_ins_monitoria", parametros);
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
        public HttpResponseMessage EditarDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_monitoria = Convert.ToInt32(form["id"]);
                string data = form["data"];
                string hora = form["hora"];
                int id_grupo = Convert.ToInt32(form["grupo"]);
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                int id_campanha = Convert.ToInt32(form["campanha"]);
                string cpf = (form["cpf"]);
                string tel = (form["tel"]);
                string persona = (form["persona"]);
                string descricao = form["descricao"];
                string link = form["link"];

                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_monitoria", id_monitoria);
                    parametros.Add("data", _data);
                    parametros.Add("id_grupo", id_grupo);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("id_campanha", id_campanha);
                    parametros.Add("cpf", cpf);
                    parametros.Add("tel", tel);
                    parametros.Add("persona", persona);
                    parametros.Add("descricao", descricao);
                    parametros.Add("link", link);

                    sql.ExecuteProcedureDataSet("sp_upd_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("remover")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage RemoverDiarioBordo(FormDataCollection form)
        {
            try
            {
                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                int id_diario_bordo = Convert.ToInt32(form["id"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("id_monitoria", id_diario_bordo);

                    sql.ExecuteProcedureDataSet("sp_del_monitoria", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
