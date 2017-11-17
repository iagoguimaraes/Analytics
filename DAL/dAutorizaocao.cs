using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dAutorizaocao
    {

        #region LOGIN / SESSAO

        public DataTable ObterUsuario(string login)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("login", login);

                    return sql.ExecuteProcedureDataTable("sp_sel_usuario_bylogin", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataTable InserirSessao(DateTime data_criacao, Usuario usuario, DateTime data_expiracao)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data_criacao", data_criacao.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("id_usuario", usuario.id_usuario.ToString());
                    parametros.Add("id_grupo", usuario.id_grupo.ToString());
                    parametros.Add("data_expiracao", data_expiracao.ToString("yyyy-MM-dd HH:mm:ss"));

                    return sql.ExecuteProcedureDataTable("sp_ins_sessao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataTable GetSessao(string id_sessao)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_sessao", id_sessao.ToString());

                    return sql.ExecuteProcedureDataTable("sp_sel_sessao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public void RenovarSessao(int id_sessao, DateTime data_expiracao)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_sessao", id_sessao.ToString());
                    parametros.Add("data_expiracao", data_expiracao.ToString("yyyy-MM-dd HH:mm:ss"));

                    sql.ExecuteProcedure("sp_upd_sessao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        #endregion

        public DataTable AcessoRecurso(int id_grupo, string path)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_grupo", id_grupo.ToString());
                    parametros.Add("path", path);

                    return sql.ExecuteProcedureDataTable("sp_sel_acessoRecurso", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataTable RegistrarRequisicao(DateTime data_requisicao, long tempo_execucao, int id_sessao, int id_recurso)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("data_requisicao", data_requisicao.ToString("yyyy-MM-dd HH:mm:ss"));
                    parametros.Add("tempo_execucao", tempo_execucao.ToString());
                    parametros.Add("id_sessao", id_sessao.ToString());
                    parametros.Add("id_recurso", id_recurso.ToString());

                    return sql.ExecuteProcedureDataTable("sp_ins_requisicao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataTable AcessoPagina(int id_grupo)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_grupo", id_grupo.ToString());

                    return sql.ExecuteProcedureDataTable("sp_sel_acessoPagina", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

    }
}
