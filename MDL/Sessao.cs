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

        public override string ToString()
        {
            return string.Concat(id_sessao.ToString(),
                ";", 
                data_criacao.ToString("yyyy-MM-dd HH:mm:ss"),
                ";", 
                id_usuario.ToString(), 
                ";",
                id_grupo.ToString());
        }

        public Sessao(DataRow row)
        {
            id_sessao = Convert.ToInt32(row["id_sessao"]);
            data_criacao = Convert.ToDateTime(row["data_criacao"]);
            id_usuario = Convert.ToInt32(row["id_usuario"]);
            id_grupo = Convert.ToInt32(row["id_grupo"]);
        }

    }
}
