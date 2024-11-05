using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Licenca
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(110, ErrorMessage = "O nome deve ter no máximo 110 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Tipo é obrigatório.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O Numero de Serie é obrigatório.")]
        public string NumeroSerie { get; set; }
        public DateTime DataAquisicao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Software { get; set; }
        public int AtivoId { get; set; } 
        public Ativo Ativo { get; set; }
    }
    
}