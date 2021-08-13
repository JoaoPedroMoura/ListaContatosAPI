using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatosAPI.Models
{
    public class Contato
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string PrimeiroNome { get; set; }
        [Required]
        public string UltimoNome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }

    }
}
