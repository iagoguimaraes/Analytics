using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dAutenticacao
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
    }
}
