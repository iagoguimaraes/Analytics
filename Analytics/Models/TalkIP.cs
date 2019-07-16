using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace Analytics.Models
{
    public class TalkIP : IDisposable
    {
        private readonly string url = "http://142.93.78.16/api/sms";
        private readonly string url_smsLote = "http://142.93.78.16/api/blocks";
        private readonly string url_callback = "https://analytics.creditcash.com.br/api/sms/talkip?";
        private readonly string url_statusLote = "http://142.93.78.16/api/blocks";

        private WebClientNT wc;

        public TalkIP()
        {
            wc = new WebClientNT();
            WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
            proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
            wc.Proxy = proxy;
        }
        public void EnviarSMS(long telefone, string mensagem, int? id_lote = null, int? id_registro = null, int contagem_erro = 0)
        {
            wc.Headers.Add("Content-Type", "application/json");
            wc.Headers.Add("Accept", "application/json");
            wc.Headers.Add("Authorization", "Basic Y3JlZF9jYXNoXzI6Y3JlZF9jYXNoX3RhbGtpcA==");


            int id_envio = RegistrarEnvio(telefone, mensagem, id_lote, id_registro);

            try
            {
                string body = JsonConvert.SerializeObject(new { phone = telefone, message = mensagem, callback = string.Format("{0}?id={1}", url_callback, id_envio) });
                string resultado = wc.UploadString(url, body);
                dynamic json = JsonConvert.DeserializeObject(resultado);

                int id_unico_fornecedor = json.id;
                double custo = json.charged;
                int status = json.status;

                AtualizarEnvio(id_envio, true, null, id_unico_fornecedor, custo);
            }
            catch (WebException e) // erro interno
            {
                HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                AtualizarEnvio(id_envio, false, (int)response.StatusCode, null, null);

                if ((int)response.StatusCode == 400)
                {
                    if (contagem_erro <= 3)
                    {
                        wc = new WebClientNT();
                        WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
                        proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
                        wc.Proxy = proxy;
                        EnviarSMS(telefone, mensagem, id_lote, id_registro, ++contagem_erro);
                    }
                }

                /*
                if ((int)response.StatusCode == 429)
                {
                    Thread.Sleep(10000);
                    EnviarSMS(telefone, mensagem, id_lote, id_registro);
                }
                */
            }
            catch (Exception)
            {
                AtualizarEnvio(id_envio, false, 1, null, null);
            }
        }
        public void EnviarLoteSMS(int id_lote, string tabela)
        {
            try
            {
                wc.Headers.Add("Content-Type", "application/json");
                wc.Headers.Add("Accept", "application/json");
                wc.Headers.Add("Authorization", "Basic Y3JlZF9jYXNoXzI6Y3JlZF9jYXNoX3RhbGtpcA==");

                // Obtem o Lote já com o layout pronto para o json;
                DataSet ds = ObterLote(id_lote, tabela);
                DataTable lote = ds.Tables[0];

                // Monta o Json do lote;
                string json = JsonConvert.SerializeObject(new { block = lote });

                // Efetua a requisição;
                string request = wc.UploadString(url_smsLote, json);
                dynamic result = JsonConvert.DeserializeObject(request);
                ConsultarStatus(Convert.ToInt16(result.id));

                //  Armazena o valor dos atribudos do request;
                int id_unico_fornecedor = result.id;
                int quantidade = result.quantiy;
                double custo = result.charged;

                // Atualiza o lote: id_unico_fornecedor, quantidade de registros e o custo;
                AtualizarLote(id_lote, id_unico_fornecedor, quantidade, custo, true, null);

            }
            catch (WebException e)
            {
                HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                AtualizarLote(id_lote, null, null, null, false, (int)response.StatusCode);

                throw new Exception(e.Message);
            }
            catch(Exception ee)
            {
                AtualizarLote(id_lote, null, null, null, false, ee.HResult);
                throw new Exception(ee.Message);
            }
        }
        public void AtualizarStatus(long id_registro, int id_layout, int codigo_status, int id_lote, int id_unico_fornecedor)
        {

            AtualizaUltimoRetorno(id_registro, id_layout);

            int id_status = 0;
            switch (codigo_status)
            {
                case 200:
                    id_status = 1; //SMS Enviado
                    break;
                case 1:
                    id_status = 3; //Em Processamento
                    break;
                case 2:
                    id_status = 2; //SMS Entregue
                    break;
                case 3:
                    id_status = 4; //Erro no envio
                    break;
                case 7:
                    id_status = 9; //Sem Saldo
                    break;
                case 11:
                    id_status = 5; //Número Inválido
                    break;
                case 12:
                    id_status = 6; //Número Bloqueado
                    break;
                case 13:
                    id_status = 7; //BlackList
                    break;
                case 14:
                    id_status = 8; //Mensagem Mal Formatada
                    break;
            }

            if (id_status > 0)
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@id_registro", id_registro);
                    parametros.Add("@id_layout", id_layout);
                    parametros.Add("@id_status", id_status);
                    parametros.Add("@id_lote", id_lote);
                    parametros.Add("@id_unico_fornecedor", id_unico_fornecedor);

                    sql.ExecuteQueryDataTable(@"insert into TB_RETORNO(id_registro, id_layout, id_status, id_lote, id_unico_fornecedor, data_retorno) values (@id_registro,@id_layout,@id_status,@id_lote,@id_unico_fornecedor,getdate())", parametros);
                }
            }
        }
        public void ConsultarStatus(int id_unico_fornecedor)
        {

            try
            {
                string response = wc.DownloadString(string.Format("{0}/{1}", url_statusLote, id_unico_fornecedor));
                dynamic result = JsonConvert.DeserializeObject(response);                

                DataTable dt = new DataTable();
                dt.Columns.Add("id_unico_fornecedor");
                dt.Columns.Add("id_status");
                dt.Columns.Add("id_registro");
                dt.Columns.Add("id_lote");
                dt.Columns.Add("id_layout");
                dt.Columns.Add("data_retorno", typeof(DateTime)).DefaultValue = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                for (int i = 0; i < result.numbers.Count; i++)
                {
                    DataRow row = dt.NewRow();

                    int id = result.numbers[i].id;
                    int id_status = result.numbers[i].status;
                    Uri uri = result.numbers[i].callback;

                    var query = uri.Query.Replace("?", "");
                    var queryValues = query.Split('&').Select(q => q.Split('=')).ToDictionary(k => k[0], v => v[1]);
                    var queryString = string.Join(";", id, id_status, string.Join(";", queryValues.Values));
                    row.ItemArray = queryString.Split(';');

                    dt.Rows.Add(row);
                }

                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    sql.BulkInsert("TB_RETORNO", dt);
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        private void AtualizarLote(int id_lote, int? id_unico_fornecedor, int? quantidade, double? custo, bool sucesso, int? id_erro)
        {

            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@id_lote", id_lote);
                parametros.Add("@sucesso", sucesso ? 1 : 0);
                parametros.Add("@id_erro", id_erro);
                parametros.Add("@id_unico_fornecedor", id_unico_fornecedor);
                parametros.Add("@quantidade", quantidade);
                parametros.Add("@custo", custo);

                sql.ExecuteQueryDataTable(@"
                        update TB_LOTE set
                             sucesso = @sucesso
                            ,id_erro = @id_erro
                            ,id_unico_fornecedor = @id_unico_fornecedor
                            ,quantidade = @quantidade
                            ,custo = @custo
                        where id_lote = @id_lote"
                , parametros);
            }


        }
        private int RegistrarEnvio(long telefone, string mensagem, int? id_lote = null, int? id_registro = null)
        {
            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                //parametros.Add("@id_fornecedor", id_fornecedor);
                parametros.Add("@telefone", telefone);
                parametros.Add("@mensagem", mensagem);
                parametros.Add("@id_lote", id_lote);
                parametros.Add("@id_registro", id_registro);

                DataTable dt = sql.ExecuteQueryDataTable(@"
                        insert into TB_ENVIO( data_envio, telefone, mensagem, id_lote, id_registro)
                        output inserted.id_envio
                        values(getdate(), @telefone, @mensagem, @id_lote, @id_registro)"
                , parametros);
                int id_envio = Convert.ToInt32(dt.Rows[0]["id_envio"]);
                return id_envio;
            }
        }
        private void AtualizarEnvio(long id_envio, bool sucesso, int? id_erro, int? id_unico_fornecedor, double? custo)
        {
            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@id_envio", id_envio);
                parametros.Add("@sucesso", sucesso ? 1 : 0);
                parametros.Add("@id_erro", id_erro);
                parametros.Add("@id_unico_fornecedor", id_unico_fornecedor);
                parametros.Add("@custo", custo);

                sql.ExecuteQueryDataTable(@"
                        update TB_ENVIO set
                             sucesso = @sucesso
                            ,id_erro = @id_erro
                            ,id_unico_fornecedor = @id_unico_fornecedor
                            ,custo = @custo
                        where id_envio = @id_envio"
                , parametros);
            }

        }
        private void AtualizaUltimoRetorno(long id_registro, int id_layout)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_SMS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@id_registro", id_registro);
                    parametros.Add("@id_layout", id_layout);

                    sql.ExecuteQueryDataTable(@"update TB_RETORNO set ultimo_retorno = 0 where id_registro = @id_registro and id_layout = @id_layout", parametros);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private DataSet ObterLote(int id_lote, string tabela)
        {

            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@id_lote", id_lote);
                parametros.Add("@tabela", tabela);
                parametros.Add("@callback", url_callback);
                return sql.ExecuteProcedureDataSet("sp_sel_lote_talkip", parametros);

            }

        }
        #region Dispose

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~TalkIP()
        {
            Dispose(false);
        }

        #endregion

    }
}