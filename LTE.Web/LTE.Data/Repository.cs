using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTE.Core;
using LTE.Core.Data;
using System.Data.Entity;

namespace LTE.Data
{
    public partial class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = (DbSet<T>)dbContext.Set<T>();
        }


        public IQueryable<T> Table
        {
            get
            {
                return _dbSet;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return _dbSet.AsNoTracking<T>();
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
