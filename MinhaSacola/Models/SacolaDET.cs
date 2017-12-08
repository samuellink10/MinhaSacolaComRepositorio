using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Models
{
    public class SacolaDET
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int SacolaCABId { get; set; }
        public SacolaCAB SacolaCAB {get;set;}
    }
}
