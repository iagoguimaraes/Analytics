using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dRiachuelo
    {
        public DataSet DashboardHoraHora(DateTime dtini, DateTime dtfim, DataTable carteiras)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

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
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    return sql.ExecuteProcedureDataSet("sp_dashboard_filtros");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(DateTime dtini, DateTime dtfim, DataTable carteiras)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_RIACHUELO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("carteiras", carteiras);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

    }
}
