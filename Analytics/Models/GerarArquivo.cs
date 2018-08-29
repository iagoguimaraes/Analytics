using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Analytics.Models
{
    public class GerarArquivo
    {

        public GerarArquivo(HttpResponse Response, DataTable dt)
        {
            try
            {
                string[] columnNames = dt.Columns.Cast<DataColumn>().
                                  Select(column => column.ColumnName).
                                  ToArray();
                Response.Output.Write(string.Join(";", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    Response.Output.Write("\r\n" + string.Join(";", fields));
                }

                Response.Flush();
                Response.End();

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }


        }
    }
}