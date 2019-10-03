using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Analytics.Models
{
    public class CsvHelper : IDisposable
    {
        private bool ValidarTelefone(string numero)
        {
            long n;

            if (!long.TryParse(numero, out n))
                return false;

            if (n.ToString().Length != 11)
                return false;

            return true;
        }

        public DataTable CarregarArquivoSimples(string path)
        {
            try
            {
                string[] linhas = File.ReadAllLines(path);

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("telefone");
                dataTable.Columns.Add("mensagem");


                for (int i = 1; i < linhas.Length; i++)
                {
                    DataRow row = dataTable.NewRow();
                    row.ItemArray = linhas[i].Split(';').Take(2).ToArray();

                    if (ValidarTelefone(row.ItemArray[0].ToString())) // telefone valido
                    {
                        if(!string.IsNullOrEmpty(row.ItemArray[1].ToString())) // contem msg 
                            dataTable.Rows.Add(row);
                    }
                        
                }

                if (dataTable.Rows.Count == 0)
                    throw new Exception("Arquivo sem nenhum registro válido");

                return dataTable;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o arquivo: " + e.Message);
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

        ~CsvHelper()
        {
            Dispose(false);
        }

        #endregion

    }
}