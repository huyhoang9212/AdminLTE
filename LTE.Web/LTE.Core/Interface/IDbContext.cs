using LTE.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTE.Core.Interface
{
    public interface IDbContext
    {
        int SaveChanges();

        IDbSet<T> Set<T>() where T : BaseEntity, IObjectState;

        void SyncObjectState<T>(T entity) where T : BaseEntity, IObjectState;

        Guid InstanceId { get; }
    }
}
