using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Analytics.Controllers
{
    [RoutePrefix("api/omne")]
    public class OmneController : ApiController
    {

        [Route("webhook")]
        [HttpPost]
        public HttpResponseMessage WebHook(JObject json)
        {
            try
            {
                Task task = new Task(() =>
                {
                    try
                    {
                        // obtem os campos para identificar o tipo do registro
                        string type = json.Value<string>("type");
                        string action = json.Value<string>("action");
                        // obtem os dados do registro
                        JToken obj = json["data"];

                        // variaveis dos dados (chave e valor) para inserir no banco de dados
                        List<Dictionary<string, string>> dados = new List<Dictionary<string, string>>();
                        Dictionary<string, string> registro = new Dictionary<string, string>();

                        // faz mapeamento dos campos conforme tipo de registro
                        if (type == "attendance")
                        {
                            registro.Add("id", obj.Value<string>("id"));
                            registro.Add("bot_name", obj.Value<string>("bot_name"));
                            registro.Add("channel", obj.Value<string>("channel"));
                            registro.Add("date_attendance", obj.Value<string>("date_attendance"));
                            registro.Add("date_entry", obj.Value<string>("date_entry"));
                            registro.Add("date_terminated", obj.Value<string>("date_terminated"));
                            registro.Add("document", obj.Value<string>("document"));
                            registro.Add("facebook", obj.Value<string>("facebook"));
                            registro.Add("mail", obj.Value<string>("mail"));
                            registro.Add("name", obj.Value<string>("name"));
                            registro.Add("phone", obj.Value<string>("phone"));
                            registro.Add("picture", obj.Value<string>("picture"));
                            registro.Add("telegram", obj.Value<string>("telegram"));
                            registro.Add("whatsapp", obj.Value<string>("whatsapp"));
                            registro.Add("status", obj.Value<string>("status"));
                            registro.Add("status_date", obj.Value<string>("status_date"));
                            registro.Add("user", obj.Value<string>("user"));

                            JArray msgs = obj.Value<JArray>("messages");
                            foreach (JToken msg in msgs)
                            {
                                Dictionary<string, string> kv = new Dictionary<string, string>();
                                kv.Add("id", msg.Value<string>("id"));
                                kv.Add("attendance_id", obj.Value<string>("id")); // id do atendimento
                                kv.Add("date_entry", msg.Value<string>("date_entry"));
                                kv.Add("origin", msg.Value<string>("origin"));
                                kv.Add("type", msg.Value<string>("type"));
                                kv.Add("channel", msg.Value<string>("channel"));
                                kv.Add("message", msg.Value<string>("message"));

                                if (kv["message"].Length > 1000) kv["message"] = "";

                                dados.Add(kv);
                            }
                        }
                        else if (type == "occurrence")
                        {
                            registro.Add("id", obj.Value<string>("id"));
                            registro.Add("attendance_id", obj.Value<string>("attendance_id"));
                            registro.Add("bot_name", obj.Value<string>("bot_name"));
                            registro.Add("date_entry", obj.Value<string>("date_entry"));
                            registro.Add("manifestation", obj.Value<string>("manifestation"));
                            registro.Add("occurrence", obj.Value<string>("occurrence"));
                            registro.Add("occurrence_group", obj.Value<string>("occurrence_group"));
                            registro.Add("user", obj.Value<string>("user"));
                        }
                        else if (type == "visitors")
                        {
                            registro.Add("id", obj.Value<string>("id"));
                            registro.Add("bot_name", obj.Value<string>("bot_name"));
                            registro.Add("browser", obj.Value<string>("browser"));
                            registro.Add("city", obj.Value<string>("city"));
                            registro.Add("country", obj.Value<string>("country"));
                            registro.Add("date_entry", obj.Value<string>("date_entry"));
                            registro.Add("ip", obj.Value<string>("ip"));
                            registro.Add("lat_long", obj.Value<string>("lat_long"));
                            registro.Add("reference", obj.Value<string>("reference"));
                            registro.Add("so", obj.Value<string>("so"));
                        }

                        dados.Add(registro);

                        if (action == "insert")
                        {
                            // montando a query
                            StringBuilder query = new StringBuilder();

                            // para cada registro (registro + mensagens)
                            foreach (Dictionary<string, string> kv in dados)
                            {
                                // faz uma instrução de insert pra query
                                string table = kv.ContainsKey("message") ? "messages" : type;
                                string fields = string.Join(",", kv.Keys.Select(x => $"[{x}]"));
                                string values = string.Join(",", kv.Values.Select(x => $"'{x}'"));
                                string _query = string.Format("insert into omne_{0}({1}) values ({2}); ", table, fields, values);
                                query.Append(_query);
                            }

                            // executa a query com os inserts
                            using (SqlHelper sql = new SqlHelper("MAURITANIA", "DB_CALLFLEX"))
                            {
                                sql.ExecuteQueryDataTable(query.ToString());
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        // se der erro, escreve na pasta de rede para termos aceso
                        string datetime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string path = @"\\venezuela\SMSAnalytics\WebHook\" + datetime + ".json";
                        File.WriteAllText(path, json.ToString());
                        path = @"\\venezuela\SMSAnalytics\WebHook2\" + datetime + ".txt";
                        File.WriteAllText(path, e.Message);
                    }
                });
                task.Start();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Filtros(FormDataCollection form)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_OMNE"))
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
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);

                using (SqlHelper sql = new SqlHelper("CUBO_OMNE"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("fila", fila);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("producao")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Producao(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable fila = JsonConvert.DeserializeObject<DataTable>(form["fila"]);


                using (SqlHelper sql = new SqlHelper("CUBO_OMNE"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini);
                    parametros.Add("dtfim", dtfim);
                    parametros.Add("fila", fila);


                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
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
