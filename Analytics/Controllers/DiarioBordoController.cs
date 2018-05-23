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
    [RoutePrefix("api/diariobordo")]
    public class DiarioBordoController : ApiController
    {

        [Route("consultar")]
        [HttpPost]
        [Autorizar]
        public HttpResponseMessage ConsultarDiarioBordo(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string empresas = form["empresas"];
                string carteiras = form["carteiras"];
                string ocorrencias = form["ocorrencias"];
                string usuarios = form["usuarios"];

                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(string.Concat(dtfim, " 23:59:59"));

                DataTable _empresas = JsonConvert.DeserializeObject<DataTable>(empresas);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);
                DataTable _ocorrencias = JsonConvert.DeserializeObject<DataTable>(ocorrencias);
                DataTable _usuarios = JsonConvert.DeserializeObject<DataTable>(usuarios);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", _dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", _dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("empresas", _empresas);
                    parametros.Add("carteiras", _carteiras);
                    parametros.Add("ocorrencias", _ocorrencias);
                    parametros.Add("usuarios", _usuarios);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_diario_bordo", parametros);
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
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_sel_opcoes_diario_bordo");
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
                string data = form["data"];
                string hora = form["hora"];
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                string descricao = form["descricao"];

                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", _data);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("descricao", descricao);

                    sql.ExecuteProcedureDataSet("sp_ins_diario_bordo", parametros);
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
                int id_diario_bordo = Convert.ToInt32(form["id"]);
                string data = form["data"];
                string hora = form["hora"];
                int id_empresa = Convert.ToInt32(form["empresa"]);
                int id_carteira = Convert.ToInt32(form["carteira"]);
                int id_ocorrencia = Convert.ToInt32(form["ocorrencia"]);
                string descricao = form["descricao"];

                Sessao sessao = (Sessao)Request.Properties["Sessao"];

                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_diario_bordo", id_diario_bordo);
                    parametros.Add("data", _data);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_usuario", sessao.id_usuario);
                    parametros.Add("descricao", descricao);

                    sql.ExecuteProcedureDataSet("sp_upd_diario_bordo", parametros);
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
                int id_diario_bordo = Convert.ToInt32(form["id"]);

                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_diario_bordo", id_diario_bordo);

                    sql.ExecuteProcedureDataSet("sp_del_diario_bordo", parametros);
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
