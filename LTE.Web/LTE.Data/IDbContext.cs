using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LTE.Core;

namespace LTE.Data
{
    public interface IDbContext
    {
        int SaveChanges();

        IDbSet<T> Set<T>() where T : BaseEntity;
    }
}
