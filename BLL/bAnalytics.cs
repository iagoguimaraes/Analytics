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

        public DataSet ConsultarDiarioBordo(string dtini, string dtfim, string empresas, string carteiras, string ocorrencias, string usuarios)
        {
            try
            {
                DateTime _dtini = Convert.ToDateTime(dtini);
                DateTime _dtfim = Convert.ToDateTime(string.Concat(dtfim, " 23:59:59"));

                DataTable _empresas = JsonConvert.DeserializeObject<DataTable>(empresas);
                DataTable _carteiras = JsonConvert.DeserializeObject<DataTable>(carteiras);
                DataTable _ocorrencias = JsonConvert.DeserializeObject<DataTable>(ocorrencias);
                DataTable _usuarios = JsonConvert.DeserializeObject<DataTable>(usuarios);

                return new dAnalytics().ConsultarDiarioBordo(_dtini, _dtfim, _empresas, _carteiras, _ocorrencias, _usuarios);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public DataSet OpcoesDiarioBordo()
        {
            try
            {
                return new dAnalytics().OpcoesDiarioBordo();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public void InserirDiarioBordo(string data, string hora, int id_empresa, int id_carteira, int id_ocorrencia, int id_usuario, string descricao)
        {
            try
            {
                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                new dAnalytics().InserirDiarioBordo(_data, id_empresa, id_carteira, id_ocorrencia, id_usuario, descricao);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }
        public void EditarDiarioBordo(int id_diario_bordo, string data, string hora, int id_empresa, int id_carteira, int id_ocorrencia, int id_usuario, string descricao)
        {
            try
            {
                DateTime _data = Convert.ToDateTime(string.Concat(data, " ", hora, ":00"));

                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                new dAnalytics().EditarDiarioBordo(id_diario_bordo, _data, id_empresa, id_carteira, id_ocorrencia, id_usuario, descricao);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }
        public void RemoverDiarioBordo(int id_diario_bordo)
        {
            try
            {
                new dAnalytics().RemoverDiarioBordo(id_diario_bordo);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
