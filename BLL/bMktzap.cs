using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Newtonsoft.Json;

namespace BLL
{
    public class bMktzap
    {
        public DataSet Dashboard(string fDtini, string fDtfim, string eDtini, string eDtfim, string campanhas, string setores)
        {
            try
            {
                DateTime minDate = Convert.ToDateTime("1753-01-01 12:00:00");
                DateTime maxDate = Convert.ToDateTime("9999-12-31 23:59:59");

                DateTime _fDtini = string.IsNullOrEmpty(fDtini) ? minDate : Convert.ToDateTime(fDtini);
                DateTime _fDtfim = string.IsNullOrEmpty(fDtfim) ? maxDate : Convert.ToDateTime(fDtfim);
                DateTime _eDtini = string.IsNullOrEmpty(eDtini) ? minDate : Convert.ToDateTime(eDtini);
                DateTime _eDtfim = string.IsNullOrEmpty(eDtfim) ? maxDate : Convert.ToDateTime(eDtfim);

                DataTable _campanhas = JsonConvert.DeserializeObject<DataTable>(campanhas);
                DataTable _setores = JsonConvert.DeserializeObject<DataTable>(setores);

                return new dMktzap().Dashboard(_fDtini, _fDtfim, _eDtini, _eDtfim, _campanhas, _setores);
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
