using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

namespace Analytics.Models
{
    public class ShortSMS : IDisposable
    {
        string url_bulk = "http://short.apisms.com.br/bot/bulk-sms.php";

        private WebClientNT wc;

        public ShortSMS()
        {
            wc = new WebClientNT();
            WebProxy proxy = new WebProxy("proxy.credit.local", 8088);
            proxy.Credentials = new NetworkCredential("automatizacaobi", "th7WruR!", "creditcash.com.br");
            wc.Proxy = proxy;
        }

        public void EnviarLoteSMS(int id_lote, string tabela)
        {
            try
            {
                wc.Headers.Add("Content-Type", "application/json");
                wc.Headers.Add("usuario", "ccdigital");
                wc.Headers.Add("chave", "5789");

                // Obtem o Lote já com o layout pronto para o json;
                DataSet ds = ObterLote(id_lote, tabela);
                DataTable lote = ds.Tables[0];

                // Monta o Json do lote;
                string json = JsonConvert.SerializeObject(new { bulk = lote });

                // Efetua a requisição;
                string request = wc.UploadString(url_bulk, json);
                dynamic result = JsonConvert.DeserializeObject(request);

                //  Armazena o valor dos atribudos do request;
                int id_unico_fornecedor = result.id;

                // obter a quantidade de registros e calcular custo
                int quantidade = result.bulk.Count;
                double custo = quantidade * 0.035;

                // Atualiza o lote: id_unico_fornecedor, quantidade de registros e o custo;
                AtualizarLote(id_lote, id_unico_fornecedor, quantidade, custo, true, null);
                
                // subir no banco resultado, ID por ID, para depois poder receber o callback
            }
            catch (WebException e)
            {
                HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                AtualizarLote(id_lote, null, null, null, false, (int)response.StatusCode);

                throw new Exception(e.Message);
            }
        }

        private DataSet ObterLote(int id_lote, string tabela)
        {

            using (SqlHelper sql = new SqlHelper("DB_SMS"))
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@id_lote", id_lote);
                parametros.Add("@tabela", tabela);
                return sql.ExecuteProcedureDataSet("sp_sel_lote_shortsms", parametros);

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

        ~ShortSMS()
        {
            Dispose(false);
        }

        #endregion

    }
}