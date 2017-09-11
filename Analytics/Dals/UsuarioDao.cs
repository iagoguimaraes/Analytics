using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Analytics
{
    public class UsuarioDao
    {
        public Usuario Logar(string login, string senha)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("login", login);
                    parametros.Add("senha", senha);

                    DataTable dt = sql.ExecuteProcedureDataTable("SP_LOGAR", parametros);

                    if (dt.Rows.Count > 0)
                        return new Usuario(dt.Rows[0]);
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao logar: " + e.Message);
            }
        }
        public bool Autorizar(int idUsuario, int idRecurso)
        {
            try
            {
                using (SqlHelper sql = new SqlHelper())
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id_usuario", idUsuario);
                    parametros.Add("id_recurso", idRecurso);

                    DataTable dt = sql.ExecuteProcedureDataTable("SP_AUTORIZAR", parametros);
                    return Convert.ToBoolean(dt.Rows[0][0]);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao autorizar: " + e.Message);
            }
        }
    }
}