using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

namespace Analytics.Models
{
    public class TalkIP : IDisposable
    {
        private readonly string url = "http://142.93.78.16/api/sms";
        private readonly string url_callback = "https://analytics.creditcash.com.br/api/sms/talkip";
        private readonly int id_fornecedor = 1;
        private WebClient wc;



        public TalkIP()
        {
            wc = new WebClient();
            WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
            proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
            wc.Proxy = proxy;
        }
        public void EnviarSMS(long telefone, string mensagem, int? id_lote = null, int? id_registro = null)
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

                if ((int)response.StatusCode == 402) // saldo insuficiente
                {
                    AtualizarEnvio(id_envio, false, 4, null, null);
                }
                else if ((int) response.StatusCode == 422) // requisição mal formada
                {
                    AtualizarEnvio(id_envio, false, 3, null, null);
                }
                else // erro na plataforma
                {
                    AtualizarEnvio(id_envio, false, 2, null, null);
                }
            }
            catch (Exception ex)
            {
                AtualizarEnvio(id_envio, false, 1, null, null);
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
        public void AtualizarStatus(long id_envio, int codigo_status)
        {
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
                    parametros.Add("@id_envio", id_envio);
                    parametros.Add("@id_status", id_status);

                    sql.ExecuteQueryDataTable(@"insert into TB_RETORNO(id_envio, id_status, data_retorno) values (@id_envio,@id_status,getdate())", parametros);
                    sql.ExecuteQueryDataTable(@"update TB_ENVIO set id_status_ultimo = @id_status where id_envio = @id_envio", parametros);
                }
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