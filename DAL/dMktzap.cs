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
        public DataSet Dashboard(DateTime fDtini, DateTime fDtfim, DateTime eDtini, DateTime eDtfim, DataTable campanhas, DataTable setores)
        {
            try
            {
                using(SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("fDtini", fDtini);
                    parametros.Add("fDtfim", fDtfim);
                    parametros.Add("eDtini", eDtini);
                    parametros.Add("eDtfim", eDtfim);
                    parametros.Add("campanhas", campanhas);
                    parametros.Add("setores", setores);

                    return sql.ExecuteProcedureDataSet("dashboard_mktzap", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public DataSet Filtros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_MKTZAP"))
                {
                    return sql.ExecuteProcedureDataSet("dashboard_mktzapFiltros");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
    }
}
