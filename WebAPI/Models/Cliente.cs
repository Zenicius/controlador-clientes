using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string EstadoCivil { get; set; } 

        public string RG { get; set; }     
        public DateTime? DataExpedicao { get; set; } 
        public string OrgaoExpedicao { get; set; }  
        public string UFExpedicao { get; set; }

        [Required]
        public string CEP { get; set; }
        [Required]
        public string Logradouro  { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }  
    }
}