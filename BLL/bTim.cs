using DAL;
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
    }
}
