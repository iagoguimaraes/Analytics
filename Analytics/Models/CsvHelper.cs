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
        public DataTable dataTable { get; set; }

        public DataTable CarregarArquivo(string arquivo, string[] quebraLinha, char delimitadorColuna)
        {
            
            //string[] str = new string[] { "\r\n" };

            string[] linhas = arquivo.Split(quebraLinha, StringSplitOptions.None);

            string[] cabecalho = linhas[0].Split(delimitadorColuna);

            for (int i = 0; i < cabecalho.Length; i++)
                dataTable.Columns.Add(cabecalho[i]);

            for (int i = 1; i < linhas.Length; i++)
            {
                DataRow row = dataTable.NewRow();
                row.ItemArray = linhas[i].Split(delimitadorColuna);
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public DataTable CarregarArquivo(string arquivo, char quebraLinha, char delimitadorColuna)
        {
            
            //string[] str = new string[] { "\r\n" };

            string[] linhas = arquivo.Split(quebraLinha);

            string[] cabecalho = linhas[0].Split(delimitadorColuna);

            for (int i = 0; i < cabecalho.Length; i++)
                dataTable.Columns.Add(cabecalho[i]);

            for (int i = 1; i < linhas.Length; i++)
            {
                DataRow row = dataTable.NewRow();
                row.ItemArray = linhas[i].Split(delimitadorColuna);
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}