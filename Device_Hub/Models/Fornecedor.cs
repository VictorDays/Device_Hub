using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(110, ErrorMessage = "O nome deve ter no máximo 110 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Contato é obrigatório.")]
        public string Contato { get; set; }
        [Required(ErrorMessage = "O Endereco é obrigatório.")]
        public string Endereco { get; set; }

        public ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();
    }
}