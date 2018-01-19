using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dPet
    {
        public DataSet DashboardHoraHora(DateTime dtini, DateTime dtfim)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_PET"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    return sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(DateTime dtini, DateTime dtfim)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_PET"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    return sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(DateTime dtini, DateTime dtfim)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_PET"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    return sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardPromessaSMS(DateTime dtini, DateTime dtfim)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_PET"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));

                    return sql.ExecuteProcedureDataSet("sp_dashboard_promessaSMS", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet CheckSMS(string id_chamada, bool sms)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_PET"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_chamada", id_chamada);
                    parametros.Add("sms", Convert.ToInt16(sms).ToString());

                    return sql.ExecuteProcedureDataSet("sp_upd_smsChamada", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
    }
}
