using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Cliente
    {
        public long? Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo CPF precisa ter 11 dígitos.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O campo Estado Civil é obrigatório.")]
        public string EstadoCivil { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "O campo RG precisa ter 8 dígitos.")]
        public string RG { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string UFExpedicao { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo CEP precisa ter 8 dígitos.")]
        public string CEP { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo Número é obrigatório.")]
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