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
        /// <summary>
        /// insere registro para a sessão (caso o usuário e senha estejam corretos)
        /// </summary>
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

        /// <summary>
        /// verifica se o grupo tem acesso ao path
        /// se tiver, retorna true o id do recurso
        /// se não tiver,retorna false e id_recurso zero.
        /// </summary>
        public bool AcessoRecurso(int id_grupo, string path, out int id_recurso)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtAcesso = dal.AcessoRecurso(id_grupo, path);

                if (dtAcesso.Rows.Count == 0)
                {
                    id_recurso = 0;
                    return false;
                }
                else
                {
                    id_recurso = Convert.ToInt32(dtAcesso.Rows[0][0]);
                    return true;
                }                 
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// registra a requisição no banco
        /// </summary>
        public void RegistrarRequisicao(long tempo_execucao, int id_sessao, int id_recurso)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                dal.RegistrarRequisicao(tempo_execucao, id_sessao, id_recurso);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

        /// <summary>
        /// obtem as paginas que um determinado grupo possui acesso
        /// </summary>
        public List<Pagina> AcessoPagina(int id_grupo)
        {
            try
            {
                dAutorizaocao dal = new dAutorizaocao();
                DataTable dtAcesso = dal.AcessoPagina(id_grupo);

                List<Pagina> paginas = new List<Pagina>();

                foreach (DataRow row in dtAcesso.Rows)
                    paginas.Add(new Pagina(row));

                return paginas;
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BLL: " + e.Message);
            }
        }

    }
}
