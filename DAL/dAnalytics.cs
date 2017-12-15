using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dAnalytics
    {
        public DataSet ConsultarGrupo()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    return sql.ExecuteProcedureDataSet("sp_sel_grupo");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public DataSet ConsultarAcesso(int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_grupo", id_grupo);

                    return sql.ExecuteProcedureDataSet("sp_sel_acesso", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public void InserirAcessoPagina(int id_pagina, int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_ins_acessoPagina", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public void RemoverAcessoPagina(int id_pagina, int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_pagina", id_pagina);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_del_acessoPagina", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public void InserirAcessoRecurso(int id_recurso, int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_ins_acessoRecurso", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public void RemoverAcessoRecurso(int id_recurso, int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_recurso", id_recurso);
                    parametros.Add("id_grupo", id_grupo);

                    sql.ExecuteProcedure("sp_del_acessoRecurso", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public DataSet ConsultarDiarioBordo(DateTime dtini, DateTime dtfim, DataTable empresas, DataTable carteiras, DataTable ocorrencias, DataTable usuarios)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("dtini", dtini.ToString("yyyy-MM-dd"));
                    parametros.Add("dtfim", dtfim.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("empresas", empresas);
                    parametros.Add("carteiras", carteiras);
                    parametros.Add("ocorrencias", ocorrencias);
                    parametros.Add("usuarios", usuarios);

                    return sql.ExecuteProcedureDataSet("sp_sel_diario_bordo", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public DataSet OpcoesDiarioBordo()
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    return sql.ExecuteProcedureDataSet("sp_sel_opcoes_diario_bordo");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }
        public void InserirDiarioBordo(DateTime data, int id_empresa, int id_carteira, int id_ocorrencia, int id_usuario, string descricao)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper("DB_ANALYTICS"))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data", data);
                    parametros.Add("id_empresa", id_empresa);
                    parametros.Add("id_carteira", id_carteira);
                    parametros.Add("id_ocorrencia", id_ocorrencia);
                    parametros.Add("id_usuario", id_usuario);
                    parametros.Add("descricao", descricao);

                    sql.ExecuteProcedureDataSet("sp_ins_diario_bordo", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

    }
}
