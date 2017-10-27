using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class Sessao
    {
        public int id_sessao { get; set; }
        public DateTime data_criacao { get; set; }
        public int id_usuario { get; set; }
        public int id_grupo { get; set; }
        public DateTime data_expiracao { get; set; }

        public override string ToString()
        {
            return string.Concat(id_sessao.ToString(),
                ";", 
                data_criacao.ToString("yyyy-MM-dd HH:mm:ss"),
                ";", 
                id_usuario.ToString(), 
                ";",
                id_grupo.ToString(),
                ";",
                data_expiracao.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public Sessao(DataRow row)
        {
            id_sessao = Convert.ToInt32(row["id_sessao"]);
            data_criacao = Convert.ToDateTime(row["data_criacao"]);
            id_usuario = Convert.ToInt32(row["id_usuario"]);
            id_grupo = Convert.ToInt32(row["id_grupo"]);
            data_expiracao = Convert.ToDateTime(row["data_expiracao"]);
        }

        public Sessao(string sessao)
        {
            string[] dados = sessao.Split(';');
            id_sessao = Convert.ToInt32(dados[0]);
            data_criacao = Convert.ToDateTime(dados[1]);
            id_usuario = Convert.ToInt32(dados[2]);
            id_grupo = Convert.ToInt32(dados[3]);
            data_expiracao = Convert.ToDateTime(dados[4]);
        }

    }
}
