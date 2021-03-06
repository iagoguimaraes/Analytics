﻿using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dTim
    {
        public DataSet Cubo()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    return sql.ExecuteProcedureDataSet("sp_sel_cubo", parametros);
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
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    return sql.ExecuteProcedureDataSet("sp_dashboard_filtros");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardHoraHora(DateTime dtini, DateTime dtfim, DataTable produtos)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_horahora", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(DateTime dtini, DateTime dtfim, DataTable produtos)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(DateTime dtini, DateTime dtfim, DataTable produtos)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardHoraHoraSinergy(DateTime dtini, DateTime dtfim, DataTable produtos)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_TIM"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("produtos", produtos);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_horahora_sinergy", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

    }
}
