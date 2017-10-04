using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using System.Data;
using DAL;

namespace BLL
{
    public class bAutorizacao
    {
        public Sessao InserirSessao(string login, string senha)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtUsuario = dal.ObterUsuario(login, senha);

                if (dtUsuario.Rows.Count == 0)
                    throw new Exception("Usuário e/ou senha incorreto(s)");

                Usuario usuario = new Usuario(dtUsuario.Rows[0]);
                DataTable dtSessao = dal.InserirSessao(usuario);
                return new Sessao(dtSessao.Rows[0]);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        public bool AcessoRecurso(int id_grupo, string path)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtAcesso = dal.AcessoRecurso(id_grupo, path);

                if (dtAcesso.Rows.Count == 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
