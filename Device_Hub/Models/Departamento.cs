using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
       
    }
}