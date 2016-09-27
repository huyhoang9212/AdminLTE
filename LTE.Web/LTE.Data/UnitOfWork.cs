using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTE.Core;
using LTE.Core.Interface;
using System.Collections;

namespace LTE.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IDbContext _dbContext;
        private readonly Hashtable _hashRepositories;

        public UnitOfWork(IDbContext dbContext)
        {
            // _dbContext = new LTEDbContext();
            _dbContext = dbContext;
            _hashRepositories = new Hashtable();
        }

        public string InstanceId()
        {
            return _dbContext.InstanceId.ToString();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            string key = typeof(T).Name;
            if(!_hashRepositories.Contains(key))
            {
                var repositoryType = typeof(Repository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this._dbContext);
                this._hashRepositories[key] = repository;
            }

            return (IRepository<T>)_hashRepositories[key];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
