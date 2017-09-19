using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class bMktzap
    {
        public DataSet Dashboard(DateTime dtini, DateTime dtfim, DataTable campanhas, DataTable setores)
        {
            try
            {
                return new dMktzap().Dashboard(dtini, dtfim, campanhas, setores);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet Filtros()
        {
            try
            {
                return new dMktzap().Filtros();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }
    }
}
