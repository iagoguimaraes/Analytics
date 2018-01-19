using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bRenner
    {
        public DataSet DashboardHoraHora(string dtini, string dtfim, string produtos)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _produtos = JsonConvert.DeserializeObject<DataTable>(produtos);

                return new dRenner().DashboardHoraHora(_dtini, _dtfim, _produtos);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardFiltros()
        {
            try
            {
                return new dRenner().DashboardFiltros();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(string dtini, string dtfim, string produtos)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _produtos = JsonConvert.DeserializeObject<DataTable>(produtos);

                return new dRenner().DashboardBTC(_dtini, _dtfim, _produtos);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(string dtini, string dtfim, string produtos)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _produtos = JsonConvert.DeserializeObject<DataTable>(produtos);

                return new dRenner().DashboardProducao(_dtini, _dtfim, _produtos);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardPagamento(string dtini, string dtfim, string produtos)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _produtos = JsonConvert.DeserializeObject<DataTable>(produtos);

                return new dRenner().DashboardPagamento(_dtini, _dtfim, _produtos);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
