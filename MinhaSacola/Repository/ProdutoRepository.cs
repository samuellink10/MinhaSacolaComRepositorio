using MinhaSacola.Data;
using MinhaSacola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Repository
{
    public class ProdutoRepository
    {
        private static ProdutoRepository _instance { get; set; }

        public static ProdutoRepository Instance { get
            {
                if (_instance == null)
                    _instance = new ProdutoRepository();

                return _instance;
            }
        }

        public List<Produto> GetAll()
        {
            return Conexao.Instance.Produtos.ToList();
        }
        public Produto Details(int? id) {


            return Conexao.Instance.Produtos.SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Create(Produto p)
        {
            Conexao.Instance.Produtos.Add(p).SaveChangesAsync();
           
        }
        public void Update(Produto p) {
            Conexao.Instance.Produtos.Update(p).SaveChangesAsync();

        }
        public void Delete(Produto p) {
            Conexao.Instance.Produtos.Remove(p).SaveChangesAsync();
        }
    }
}
