using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Analytics
{
    public class Sessao
    {
        public int id_sessao { get; set; }
        public DateTime data_criacao { get; set; }
        public int id_usuario { get; set; }
        public DateTime data_expiracao { get; set; }

        public override string ToString()
        {
            return string.Concat(id_sessao.ToString(),
                ";",
                data_criacao.ToString("yyyy-MM-dd HH:mm:ss"),
                ";",
                id_usuario.ToString(),
                ";",
                data_expiracao.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public Sessao(DataRow row)
        {
            id_sessao = Convert.ToInt32(row["id_sessao"]);
            data_criacao = Convert.ToDateTime(row["data_criacao"]);
            id_usuario = Convert.ToInt32(row["id_usuario"]);
            data_expiracao = Convert.ToDateTime(row["data_expiracao"]);
        }

        public Sessao(string sessao)
        {
            string[] dados = sessao.Split(';');
            id_sessao = Convert.ToInt32(dados[0]);
            data_criacao = Convert.ToDateTime(dados[1]);
            id_usuario = Convert.ToInt32(dados[2]);
            data_expiracao = Convert.ToDateTime(dados[3]);
        }

    }
}