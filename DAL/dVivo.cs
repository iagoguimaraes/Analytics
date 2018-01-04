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
        public DataSet DashboardHoraHora(DateTime data, DataTable segmentacoes, DataTable campanhas)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
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

        public DataSet DashboardProducao(DateTime dtini, DateTime dtfim, DataTable segmentacoes, DataTable campanhas)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_producao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(DateTime dtini, DateTime dtfim, DataTable segmentacoes, DataTable campanhas)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);
                    parametros.Add("campanhas", campanhas);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_btc", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardLote()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    return sql.ExecuteProcedureDataSet("sp_dashboard_lote");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataSet DashboardPagamento(DateTime dtini, DateTime dtfim, DataTable segmentacoes)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("CUBO_VIVO"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd"));
                    parametros.Add("segmentacoes", segmentacoes);

                    return sql.ExecuteProcedureDataSet("sp_dashboard_pagamento", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
    }
}
