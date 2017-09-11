using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Analytics
{
    public class Usuario
    {
        private int idUsuario;
        private string login;
        private string nome;
        private DateTime dataCriacao;
        private bool ativo;
        private int idNivel;

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public DateTime DataCriacao
        {
            get
            {
                return dataCriacao;
            }

            set
            {
                dataCriacao = value;
            }
        }

        public bool Ativo
        {
            get
            {
                return ativo;
            }

            set
            {
                ativo = value;
            }
        }

        public int IdNivel
        {
            get
            {
                return idNivel;
            }

            set
            {
                idNivel = value;
            }
        }

        public Usuario()
        {

        }

        public Usuario(DataRow row)
        {
            idUsuario = Convert.ToInt32(row["id_usuario"]);
            login = row["login"].ToString();
            nome = row["nome"].ToString();
            dataCriacao = Convert.ToDateTime(row["data_criacao"]);
            ativo = Convert.ToBoolean(row["ativo"]);
            idNivel = Convert.ToInt32(row["id_nivel"]);
        }
    }
}