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
    [RoutePrefix("api/telecom")]
    public class TelecomController : ApiController
    {
        [Route("filtros")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Filtros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
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

        [Route("horahora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage HoraHora(FormDataCollection form)
        {
            try
            {
                DateTime data = Convert.ToDateTime(form["data"]);
                DataTable fornecedor = JsonConvert.DeserializeObject<DataTable>(form["fornecedor"]);
                DataTable plataforma = JsonConvert.DeserializeObject<DataTable>(form["plataforma"]);
                DataTable operadora = JsonConvert.DeserializeObject<DataTable>(form["operadora"]);
                DataTable tipochamada = JsonConvert.DeserializeObject<DataTable>(form["tipochamada"]);
                DataTable rota = JsonConvert.DeserializeObject<DataTable>(form["rota"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));
                    parametros.Add("fornecedor", fornecedor);
                    parametros.Add("plataforma", plataforma);
                    parametros.Add("operadora", operadora);
                    parametros.Add("tipochamada", tipochamada);
                    parametros.Add("rota", rota);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("historico")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Historico(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable fornecedor = JsonConvert.DeserializeObject<DataTable>(form["fornecedor"]);
                DataTable plataforma = JsonConvert.DeserializeObject<DataTable>(form["plataforma"]);
                DataTable operadora = JsonConvert.DeserializeObject<DataTable>(form["operadora"]);
                DataTable tipochamada = JsonConvert.DeserializeObject<DataTable>(form["tipochamada"]);
                DataTable rota = JsonConvert.DeserializeObject<DataTable>(form["rota"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("fornecedor", fornecedor);
                    parametros.Add("plataforma", plataforma);
                    parametros.Add("operadora", operadora);
                    parametros.Add("tipochamada", tipochamada);
                    parametros.Add("rota", rota);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_historico", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("inserir/operadora")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirOperadora(FormDataCollection form)
        {
            try
            {
                string operadora = form["operadora"].ToString();

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("operadora", operadora);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_dimOperadora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("inserir/carteira")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirCarteira(FormDataCollection form)
        {
            try
            {
                string carteira = form["carteira"].ToString();

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("carteira", carteira);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_dimCarteira", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("inserir/gerente")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage InserirGerente(FormDataCollection form)
        {
            try
            {
                string gerente = form["gerente"].ToString();

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("gerente", gerente);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_ins_dimGerente", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("atualizar/rota")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage AtualizarRota(FormDataCollection form)
        {
            try
            {
                int id_rota = Convert.ToInt32(form["id_rota"]);
                int id_operadora = Convert.ToInt32(form["id_operadora"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_rota", id_rota);
                    parametros.Add("id_operadora", id_operadora);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_dimRota", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("atualizar/fila")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage AtualizarFila(FormDataCollection form)
        {
            try
            {
                int id_fila = Convert.ToInt32(form["id_fila"]);
                int id_carteira = Convert.ToInt32(form["id_carteira"]);
                int id_gerente = Convert.ToInt32(form["id_gerente"]);

                using (SqlHelper sql = new SqlHelper("CUBO_TELECOM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_fila", id_fila);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_gerente", id_gerente);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_upd_dimFila", parametros);
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
