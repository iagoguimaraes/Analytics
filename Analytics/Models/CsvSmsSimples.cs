using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Analytics.Models
{
    public class CsvSmsSimples
    {

        public DataTable CarregarArquivo(string arquivo, int id_lote)
        {
            string[] str = new string[] { "\r\n" };
            string[] linhas = arquivo.Split(str, StringSplitOptions.None);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("telefone");
            dataTable.Columns.Add("mensagem");
            dataTable.Columns.Add("cpf");
            dataTable.Columns.Add("id_lote", typeof(int)).DefaultValue = id_lote;

            for (int i = 1; i < linhas.Length - 1; i++)
            {
                DataRow row = dataTable.NewRow();
                row.ItemArray = linhas[i].Split(';');
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

    }
}