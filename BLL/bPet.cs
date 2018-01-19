using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bPet
    {
        public DataSet DashboardHoraHora(string dtini, string dtfim)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);

                return new dPet().DashboardHoraHora(_dtini, _dtfim);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(string dtini, string dtfim)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);

                return new dPet().DashboardBTC(_dtini, _dtfim);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(string dtini, string dtfim)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);

                return new dPet().DashboardProducao(_dtini, _dtfim);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardPromessaSMS(string dtini, string dtfim)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);

                return new dPet().DashboardPromessaSMS(_dtini, _dtfim);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet CheckSMS(string id_chamada, string sms)
        {
            try
            {
                string _id_chamada = id_chamada;
                bool _sms = Convert.ToBoolean(sms);

                return new dPet().CheckSMS(_id_chamada, _sms);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }
    }
}
