using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTE.Core;
using LTE.Core;

namespace LTE.Core.Interface
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        string InstanceId();
    }
}
