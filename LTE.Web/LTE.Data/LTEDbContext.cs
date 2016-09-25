using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTE.Core.Data;
using System.Data.Entity;
using LTE.Core.Domain;
using LTE.Core;
using LTE.Data.Mapping;

namespace LTE.Data
{
    public class LTEDbContext : DbContext, IDbContext
    {
        public LTEDbContext()
            : base("name=LTEDbContext")
        {

        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryMapping());
        }

        DbSet<Category> Categories { get; set; }
    }
}
