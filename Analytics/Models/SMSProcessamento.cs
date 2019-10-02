using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class SMSProcessamento
    {
        public int id_usuario { get; set; }
        public int id_carteira { get; set; }
        public int id_centrocusto { get; set; }
        public int id_fornecedor { get; set; }
        public string arquivo { get; set; }
        public int sucesso { get; set; }
        public string motivo_erro { get; set; }
        public int qtd_registros { get; set; }
        public int qtd_enviado { get; set; }
        public double custo { get; set; }
        public SMSProcessamento() { }
    }
}