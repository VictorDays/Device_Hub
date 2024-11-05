using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Device_Hub.Models
{
    public class Ativo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do equipamento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Descricao do equipamento é obrigatório.")]
        [StringLength(350, ErrorMessage = "O nome deve ter no máximo 350 caracteres.")]
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        [Required(ErrorMessage = "O Fabricante do equipamento é obrigatório.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O Modelo do equipamento é obrigatório.")]
        public string NumeroSerie { get; set; }
        [Required(ErrorMessage = "A Data de Aquisicao do equipamento é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataAquisicao { get; set; }
        public float Valor { get; set; }
        public string Localizacao { get; set; }
        public string Status { get; set; }
        public Garantia Garantia { get; set; } // Propriedade de navegação para Garantia
        public ICollection<Licenca> Licencas { get; set; } = new List<Licenca>();
        public ICollection<Manutencao> Manutencoes { get; set; } = new List<Manutencao>();
        public int? ResponsavelId { get; set; } // Chave estrangeira para Funcionario
        public Funcionario Responsavel { get; set; }
        public int? DepartamentoId { get; set; } // Chave estrangeira para Departamento
        public Departamento Departamento { get; set; }
        public int? FornecedorId { get; set; } // Chave estrangeira para Fornecedor
        public Fornecedor Fornecedor { get; set; }
    }
}