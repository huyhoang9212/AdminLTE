using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTE.Core.Infrastructure
{
    public class ObjectStateHelper
    {
       public static EntityState ConvertState(ObjectState state)
        {
            switch(state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Detached:
                    return EntityState.Detached;

                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
