using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dVivo
    {
        public DataSet DashboardHoraHora(DateTime dtini, DateTime dtfim, DataTable campanhas)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("campanhas", campanhas);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardFiltros()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    return sql.ExecuteProcedureDataSet("sp_dashboard_filtros");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

    }
}
