using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bAnalytics
    {
        public DataSet ConsultarGrupo()
        {
            try
            {
                return new dAnalytics().ConsultarGrupo();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }
        public DataSet ConsultarAcesso(int id_grupo)
        {
            try
            {
                return new dAnalytics().ConsultarAcesso(id_grupo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public void InserirAcessoPagina(int id_pagina, int id_grupo)
        {
            try
            {
                new dAnalytics().InserirAcessoPagina(id_pagina, id_grupo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public void RemoverAcessoPagina(int id_pagina, int id_grupo)
        {
            try
            {
                new dAnalytics().RemoverAcessoPagina(id_pagina, id_grupo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public void InserirAcessoRecurso(int id_recurso, int id_grupo)
        {
            try
            {
                new dAnalytics().InserirAcessoRecurso(id_recurso, id_grupo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public void RemoverAcessoRecurso(int id_recurso, int id_grupo)
        {
            try
            {
                new dAnalytics().RemoverAcessoRecurso(id_recurso, id_grupo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
