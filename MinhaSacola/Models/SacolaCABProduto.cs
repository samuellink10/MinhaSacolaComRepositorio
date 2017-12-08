using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Models
{
    public class SacolaCABProduto
    {
        public List<Produto> produto { get; set; }
        public SacolaCAB Sacola { get; set; }
    }
}
