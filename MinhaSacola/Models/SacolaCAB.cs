using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Models
{
    public class SacolaCAB
    {
        [Required]
        public int Id { get; set; }
        [Required ,StringLength(100)]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
