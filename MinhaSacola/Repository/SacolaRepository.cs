using MinhaSacola.Data;
using MinhaSacola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Repository
{
    public class SacolaRepository
    {
        private static SacolaRepository _instance { get; set; }
        public static SacolaRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SacolaRepository();

                return _instance;
            }
        }
        public List<SacolaCAB> GetAll()
        {
            return Conexao.Instance.SacolaCABs.ToListAsync();
        }

        public void Create(string descricao, List<int> ids) {
            SacolaCAB s = new SacolaCAB();
            SacolaDET d = new SacolaDET();
            s.Descricao = descricao;
            s.DataCriacao = DateTime.Now;
            Conexao.Instance.SacolaCABs.Add(s).SaveChangesAsync();

            foreach (var item in ids)
            {
                d.ProdutoId = item;
                d.SacolaCABId = s.Id;
                Conexao.Instance.SacolaDETs.Add(d);
            }


        }

        public SacolaCAB Edit(int? id)
        {
            return Conexao.Instance.SacolaCABs.SingleOrDefaultAsync(m => m.Id == id);
        }
        public void Update(SacolaCAB s) {
            Conexao.Instance.SacolaCABs.Update(s);
        }
        public void Delete(SacolaCAB s) {
            Conexao.Instance.SacolaCABs.Remove(s);
        }

        public void DeleteSacolaDetails(SacolaDET s)
        {
            Conexao.Instance.SacolaDETs.Remove(s);
        }

        public SacolaDET GetDetailSingle(int? id) {

            return Conexao.Instance.SacolaDETs
                .Include(s => s.Produto)
                .Include(s => s.SacolaCAB)
                .SingleOrDefaultAsync(m => m.Id == id);
        }
        public List<SacolaDET> GetDetails(int id)
        {
            return Conexao.Instance.SacolaDETs.Where(s => s.SacolaCAB.Id == id).Include(s => s.Produto).Include(s => s.SacolaCAB);
        }

    }
}
