using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetALL();
        T Get(int id);

        void Add(T entity);
        void Remove(T entity);
        void RemoveByRange(IEnumerable<T> entity);
       
    }
}
