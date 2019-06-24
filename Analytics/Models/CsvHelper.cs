using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Analytics.Models
{
    public class CsvHelper
    {

        private void ValidarTelefone(string numero)
        {
            long n;
            long.TryParse(numero, out n);

            if (n == 0)
            {
                throw new Exception("Coluna TELEFONE não pode conter textos ou carácter especial");
            }
        }

        public DataTable CarregarArquivoSimples(string arquivo, int id_lote)
        {
            try
            {
                string[] str = new string[] { "\r\n" };
                string[] linhas = arquivo.Split(str, StringSplitOptions.None);

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("telefone");
                dataTable.Columns.Add("mensagem");
                dataTable.Columns.Add("cpf");
                dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;
                
                try
                {
                    for (int i = 1; i < linhas.Length - 1; i++)
                    {
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = linhas[i].Split(';');
                        ValidarTelefone(row.ItemArray[0].ToString());
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception)
                {
                    throw new Exception("Arquivo não possui a quantidade correta de colunas para este layout");
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}