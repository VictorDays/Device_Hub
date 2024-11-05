using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Manutencao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public float Custo { get; set; }
        public int AtivoId { get; set; } // Chave estrangeira para Ativo
        public Ativo Ativo { get; set; }
    }
}