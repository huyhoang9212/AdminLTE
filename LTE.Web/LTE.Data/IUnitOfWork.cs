using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTE.Core.Data;
using LTE.Core;

namespace LTE.Data
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
