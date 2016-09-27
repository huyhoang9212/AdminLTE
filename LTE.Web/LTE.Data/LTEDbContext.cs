using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using LTE.Core.Domain;
using LTE.Core;
using LTE.Data.Mapping;
using LTE.Core.Interface;
using LTE.Core.Infrastructure;

namespace LTE.Data
{
    public class LTEDbContext : DbContext, IDbContext
    {
        private readonly Guid _instanceId;
        public LTEDbContext()
            : base("name=LTEDbContext")
        {
            _instanceId = Guid.NewGuid();
        }

        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryMapping());
        }

        public void SyncObjectState<T>(T entity) where T : BaseEntity, IObjectState
        {
            this.Entry(entity).State = ObjectStateHelper.ConvertState(entity.ObjectState);
        }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
