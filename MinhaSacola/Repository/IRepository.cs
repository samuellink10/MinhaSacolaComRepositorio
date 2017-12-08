using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSacola.Repository
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T[] GetAll();
        void Save(T entity);
        void Delete(T entity);
    }
}
