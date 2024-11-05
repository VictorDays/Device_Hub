using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Garantia
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int FornecedorId { get; set; } 
        public Fornecedor Fornecedor { get; set; }

        public int AtivoId { get; set; } // Chave estrangeira para Ativo
        public Ativo Ativo { get; set; }
    }
    
}