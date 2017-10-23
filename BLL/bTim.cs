﻿using DAL;
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

        public DataSet DashboardHoraHora(DateTime dtini, DateTime dtfim, DataTable campanhas)
        {
            try
            {
                return new dTim().DashboardHoraHora(dtini,dtfim, campanhas);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
