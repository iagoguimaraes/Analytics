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
        public DataSet Dashboard()
        {
            try
            {
                dMktzap dao = new dMktzap();
                return dao.Dashboard();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar: " + e.Message);
            }
        }
    }
}
