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
    public class bVivo
    {
        public DataSet DashboardHoraHora(string data, string segmentacoes, string campanhas)
        {
            try
            {
                DateTime _data = Convert.ToDateTime(data);
                DataTable _segmentacoes = JsonConvert.DeserializeObject<DataTable>(segmentacoes);
                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);              

                return new dVivo().DashboardHoraHora(_data, _segmentacoes, _campanhas);
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
                return new dVivo().DashboardFiltros();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(string dtini, string dtfim, string segmentacoes, string campanhas)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _segmentacoes = JsonConvert.DeserializeObject<DataTable>(segmentacoes);
                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);

                return new dVivo().DashboardProducao(_dtini, _dtfim, _segmentacoes, _campanhas);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(string dtini, string dtfim, string segmentacoes, string campanhas)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _segmentacoes = JsonConvert.DeserializeObject<DataTable>(segmentacoes);
                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);

                return new dVivo().DashboardBTC(_dtini, _dtfim, _segmentacoes, _campanhas);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardLote()
        {
            try
            {
                return new dVivo().DashboardLote();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardPagamento(string dtini, string dtfim, string segmentacoes)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _segmentacoes = JsonConvert.DeserializeObject<DataTable>(segmentacoes);

                return new dVivo().DashboardPagamento(_dtini, _dtfim, _segmentacoes);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
