using Analytics.Models;
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
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Analytics.Controllers
{
    [RoutePrefix("api/sms")]
    public class SMSController : ApiController
    {
        [Route("filtros")]
        [HttpGet]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Filtros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_filtros");
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("upload")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Upload(FormDataCollection form)
        {
            try
            {
                string nomearquivo = form["nomearquivo"];
                string blob = form["arquivo"];
                byte[] data = Convert.FromBase64String(blob.Substring(blob.IndexOf(",") + 1));

                if (nomearquivo.Substring(nomearquivo.Length - 4) != ".csv")
                    throw new Exception("formato inválido");
                if (File.Exists(string.Format(@"\\venezuela\SMSAnalytics\{0}", nomearquivo)))
                    throw new Exception("Este arquivo já foi importado");
                if (File.Exists(string.Format(@"\\venezuela\SMSAnalytics\Processados\{0}", nomearquivo)))
                    throw new Exception("Este arquivo já foi processado");

                File.WriteAllBytes(string.Format(@"\\venezuela\SMSAnalytics\{0}", nomearquivo), data);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("listararquivos")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ListarArquivos(FormDataCollection form)
        {
            try
            {
                string[] arquivos = Directory.GetFiles(@"\\venezuela\SMSAnalytics");
                arquivos = arquivos.Select(f => f.Replace(@"\\venezuela\SMSAnalytics\", "")).ToArray();

                string[] rejeitados = Directory.GetFiles(@"\\venezuela\SMSAnalytics\Rejeitados\");
                rejeitados = rejeitados.Select(f => f.Replace(@"\\venezuela\SMSAnalytics\Rejeitados\", "")).ToArray();

                return Request.CreateResponse(HttpStatusCode.OK, new[] { arquivos, rejeitados });
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("removerarquivo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RemoverArquivo(FormDataCollection form)
        {
            try
            {
                File.Delete(string.Format(@"\\venezuela\SMSAnalytics\{0}", form["arquivo"]));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("removerarquivorejeitado")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage RemoverArquivoRejeitado(FormDataCollection form)
        {
            try
            {
                File.Delete(string.Format(@"\\venezuela\SMSAnalytics\Rejeitados\{0}", form["arquivo"]));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("reutilizararquivo")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ReutilizarArquivo(FormDataCollection form)
        {
            try
            {
                string pathAtual = string.Format(@"\\venezuela\SMSAnalytics\Rejeitados\{0}", form["arquivo"]);
                string novoPath = string.Format(@"\\venezuela\SMSAnalytics\{0}", form["arquivo"]);

                if (File.Exists(novoPath))
                    novoPath = novoPath.Replace(".csv", DateTime.Now.ToString("_yyyyMMddHHmmss") + ".csv");

                File.Move(pathAtual, novoPath);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("processar/talkip")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ProcessarTalkIP(FormDataCollection form)
        {
            try
            {
                //string arquivoSelecionado = form["arquivoSelecionado"];
                //string centrocusto = form["centrocusto"];
                //string carteira = form["carteira"];
                //string fornecedor = form["fornecedor"];

                string retorno = "Processamento para este fornecedor não foi implementado";

                return Request.CreateResponse(HttpStatusCode.InternalServerError, retorno);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("processar/vocalnet")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage ProcessarVocalNet(FormDataCollection form)
        {
            try
            {
                string path = @"\\venezuela\SMSAnalytics";

                string arquivoSelecionado = form["arquivoSelecionado"];
                int centrocusto = Convert.ToInt32(form["centrocusto"]);
                int carteira = Convert.ToInt32(form["carteira"]);               
                string token = form["token"];
                int fornecedor = 2;

                Sessao sessao = (Sessao)Request.Properties["Sessao"];
                int id_usuario = Convert.ToInt16(sessao.id_usuario.ToString());

                DataTable arquivo = new DataTable();

                bool sucesso = false;
                string motivo_erro = null;
                int qtd_registros = 0;
                int qtd_enviado = 0;
                double custo = 0;
                bool prosseguir = true;

                if (!(DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 20))
                {
                    motivo_erro = "Fora do horário permitido";
                    prosseguir = false;
                }

                // CARREGAR ARQUIVO
                if (prosseguir)
                {
                    try
                    {
                        using (CsvHelper csv = new CsvHelper())
                        {
                            arquivo = csv.CarregarArquivoSimples(string.Format(@"{0}\{1}", path, arquivoSelecionado));
                        }

                        qtd_registros = arquivo.Rows.Count;
                    }
                    catch (Exception e)
                    {
                        motivo_erro = "Arquivo inválido: " + e.Message;
                        prosseguir = false;
                    }
                }
                

                // PROCESSAR
                if (prosseguir)
                {                   
                    try
                    {
                        using (VocalNET vc = new VocalNET(token))
                        {
                            qtd_enviado = vc.ProcessarArquivo(arquivoSelecionado, arquivo);
                            custo = qtd_enviado * 0.04;
                        }
                        sucesso = true;
                    }
                    catch (Exception e)
                    {
                        motivo_erro = "Erro no processamento: " + e.Message;
                    }
                }
                

                // SUIBR DADOS               
                SMSProcessamento p = new SMSProcessamento();
                p.arquivo = arquivoSelecionado;
                p.id_centrocusto = centrocusto;
                p.id_carteira = carteira;
                p.id_fornecedor = fornecedor;
                p.id_usuario = id_usuario;
                p.sucesso = sucesso ? 1 : 0;
                p.motivo_erro = motivo_erro;
                p.qtd_registros = qtd_registros;
                p.qtd_enviado = qtd_enviado;
                p.custo = custo;
                InserirTabelaProcessamento(p);

                // MOVER ARQUIVO
                string pathProcessado = string.Format(@"{0}\Processados\{1}", path, arquivoSelecionado);
                string pathAtual = string.Format(@"{0}\{1}", path, arquivoSelecionado);

                if(!sucesso)
                    pathProcessado = string.Format(@"{0}\Rejeitados\{1}", path, arquivoSelecionado);
                if (File.Exists(pathProcessado))
                    pathProcessado = pathProcessado.Replace(".csv", DateTime.Now.ToString("_yyyyMMddHHmmss") + ".csv");

                File.Move(pathAtual, pathProcessado);

                if (sucesso)
                    return Request.CreateResponse(HttpStatusCode.OK, "OK");
                else
                    throw new Exception("Erro ao importar o arquivo");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/acompanhamento")]
        [HttpPost]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardAcompanhamento(FormDataCollection form)
        {
            try
            {
                DateTime dtini = Convert.ToDateTime(form["dtini"]);
                DateTime dtfim = Convert.ToDateTime(form["dtfim"]);
                DataTable centrocusto = JsonConvert.DeserializeObject<DataTable>(form["centrocusto"]);
                DataTable carteiras = JsonConvert.DeserializeObject<DataTable>(form["carteiras"]);
                DataTable fornecedores = JsonConvert.DeserializeObject<DataTable>(form["fornecedores"]);
                DataTable usuarios = JsonConvert.DeserializeObject<DataTable>(form["usuarios"]);

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {

                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("centrocusto", centrocusto);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("fornecedores", fornecedores);
                    parametros.Add("usuarios", usuarios);

                    DataSet resultado = sql.ExecuteProcedureDataSet("sp_dashboard_acompanhamento", parametros);
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private void InserirTabelaProcessamento(SMSProcessamento p)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", p.id_usuario);
                    parametros.Add("id_carteira", p.id_carteira);
                    parametros.Add("id_centrocusto", p.id_centrocusto);
                    parametros.Add("id_fornecedor", p.id_fornecedor);
                    parametros.Add("arquivo", p.arquivo);
                    parametros.Add("sucesso", p.sucesso);
                    parametros.Add("motivo_erro", p.motivo_erro);
                    parametros.Add("qtd_registros", p.qtd_registros);
                    parametros.Add("qtd_enviado", p.qtd_enviado);
                    parametros.Add("custo", p.custo.ToString().Replace(",", "."));

                    sql.ExecuteProcedure("sp_ins_processamento", parametros);
                }

            }
            catch { }
        }


    }
}
