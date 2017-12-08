using Microsoft.EntityFrameworkCore;
using MinhaSacola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Data
{
    public class Conexao : DbContext

    {
        private static Conexao _instance { get; set; }  
        private static DbContextOptions<Conexao> _options { get; set; } 

        public Conexao(DbContextOptions<Conexao> options) : base(options) {

            if (_options == null)
                _options = options;
        }

        public static Conexao Instance
        {
            get {
                if (_instance == null)
                    _instance = new Conexao(_options);

                return _instance;
            }

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SacolaCAB> SacolaCABs { get; set; }
        public DbSet<SacolaDET> SacolaDETs { get; set; }
    }
}
