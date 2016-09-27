using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTE.Core.Interface
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T FindById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }

       // void SyncObjectState(T entity);
    }
}
