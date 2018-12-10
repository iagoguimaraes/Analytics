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

    }
}
