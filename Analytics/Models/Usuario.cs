using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Analytics
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public DateTime data_criacao { get; set; }
        public bool ativo { get; set; }

        public Usuario(DataRow row)
        {
            id_usuario = Convert.ToInt32(row["id_usuario"]);
            nome = Convert.ToString(row["nome"]);
            login = Convert.ToString(row["login"]);
            data_criacao = Convert.ToDateTime(row["data_criacao"]);
            ativo = Convert.ToBoolean(row["ativo"]);
        }
    }
}