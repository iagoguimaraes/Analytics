﻿using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bRiachuelo
    {
        public DataSet DashboardHoraHora(string dtini, string dtfim, string carteiras)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);

                return new dRiachuelo().DashboardHoraHora(_dtini, _dtfim, _carteiras);
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
                return new dRiachuelo().DashboardFiltros();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardBTC(string dtini, string dtfim, string carteiras)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);

                return new dRiachuelo().DashboardBTC(_dtini, _dtfim, _carteiras);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet DashboardProducao(string dtini, string dtfim, string carteiras)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(dtfim);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);

                return new dRiachuelo().DashboardProducao(_dtini, _dtfim, _carteiras);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}