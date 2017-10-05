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
        public DataTable ObterUsuario(string login, string senha)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("login", login);
                    parametros.Add("senha", senha);

                    return sql.ExecuteProcedureDataTable("sp_sel_usuario_bylogin", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

        public DataTable InserirSessao(Usuario usuario)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("id_usuario", usuario.id_usuario.ToString());
                    parametros.Add("id_grupo", usuario.id_grupo.ToString());

                    return sql.ExecuteProcedureDataTable("sp_ins_sessao", parametros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro DAL: " + e.Message);
            }
        }

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

        public DataTable RegistrarRequisicao(long tempo_execucao, int id_sessao, int id_recurso)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

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

    }
}
