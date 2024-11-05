using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(110, ErrorMessage = "O nome deve ter no máximo 110 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Cargo { get; set; }
        public int? DepartamentoId { get; set; } // Chave estrangeira para Departamento
        public Departamento Departamento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();
    }
}