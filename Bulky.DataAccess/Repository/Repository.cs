using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

       

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
            
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(int id)
        {
           var foundId = _dbSet.Find(id);
            return foundId;
        }

        public IEnumerable<T> GetALL()
        {
            var list = _dbSet.ToList();   
            return list;
        }

        public void Remove(T entity)
        {
           _dbSet.Remove(entity);
        }

        public void RemoveByRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        
    }
}
