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
    public class bTim
    {
        public DataSet Cubo()
        {
            try
            {
                return new dTim().Cubo();
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
                return new dTim().DashboardFiltros();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardHoraHora(string dtini, string dtfim, string produtos)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _produtos = JsonConvert.DeserializeObject<DataTable>(produtos);

                return new dTim().DashboardHoraHora(_dtini, _dtfim, _produtos);
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

                return new dTim().DashboardBTC(_dtini, _dtfim, _produtos);
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

                return new dTim().DashboardProducao(_dtini, _dtfim, _produtos);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
