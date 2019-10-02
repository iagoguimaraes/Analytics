using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace Analytics.Models
{
    public class VocalNET : IDisposable
    {
        private string url = "http://sms.vocalnet.com.br/api/envio.php";      
        private string token = null;
        private string path = @"\\venezuela\SMSAnalytics\Logs\VocalNET\";

        public VocalNET(string token)
        {         
            this.token = token;
        }

        public int ProcessarArquivo(string nomeArquivo, DataTable arquivo)
        {
            int qtd_enviado = 0;

            arquivo.Columns[0].ColumnName = "destino";
            arquivo.Columns[1].ColumnName = "msg";

            List<DataTable> arquivos = SplitDataTable(arquivo, 1000);

            for (int i = 0; i < arquivos.Count; i++)
            {
                DataTable mensagens = arquivos[i];
                string logPath = string.Format("{0}{1}_{2}_{3}.json", path, nomeArquivo, i, DateTime.Now.ToString("yyyyMMddHHmmss"));

                try
                {
                    string json = JsonConvert.SerializeObject(new Object[] { new { token = token, mensagens = mensagens } });
                    string response = HttpPost(json);
                    qtd_enviado += Regex.Matches(response, "\"status\":200").Count;
                    File.WriteAllText(logPath, response);
                }
                catch { }
            }
 
            return qtd_enviado;
        }

        private List<DataTable> SplitDataTable(DataTable dt, int chunkSize)
        {
            List<DataTable> dts = new List<DataTable>();

            int itemsReturned = 0;
            var list = dt.AsEnumerable().ToList();
            int count = list.Count;
            while (itemsReturned < count)
            {
                int currentChunkSize = Math.Min(chunkSize, count - itemsReturned);
                dts.Add(list.GetRange(itemsReturned, currentChunkSize).CopyToDataTable());
                itemsReturned += currentChunkSize;
            }
            return dts;
        }

        private string HttpPost(string json)
        {
            string result;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";         
            httpWebRequest.Headers["Proxy-Authorization"] = "Basic YXV0b21hdGl6YWNhb2JpOnRoN1dydVIh";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
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

        ~VocalNET()
        {
            Dispose(false);
        }

        #endregion
    }
}