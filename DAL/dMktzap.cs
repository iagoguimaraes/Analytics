using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dMktzap
    {
        public DataSet Dashboard()
        {
            try
            {
                using(SqlHelper sql = new SqlHelper("CUBO_CREDITCASH"))
                {
                    return sql.ExecuteProcedureDataSet("dashboard_mktzap");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter dados: " + e.Message);
            }
        }
    }
}
