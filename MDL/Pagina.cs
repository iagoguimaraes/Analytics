﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class Pagina
    {
        public int id_pagina { get; set; }
        public string path { get; set; }
        public string nome { get; set; }
        public string url { get; set; }
        public string icone { get; set; }
        public string imagem { get; set; }
        public int ordem { get; set; }
        

        public Pagina(DataRow row)
        {
            id_pagina = Convert.ToInt32(row["id_pagina"]);
            path = row["path"].ToString();
            nome = row["nome"].ToString();
            url = row["url"].ToString();
            icone = row["icone"].ToString();
            imagem = row["imagem"].ToString();
            ordem = Convert.ToInt32(row["ordem"]);
        }
    }
}
