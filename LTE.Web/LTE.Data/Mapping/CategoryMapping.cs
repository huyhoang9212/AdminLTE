using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using LTE.Core.Domain;

namespace LTE.Data.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        
        public CategoryMapping()
        {
            // Primary key
            this.HasKey(c => c.Id);

            // Properties
            this.Property(c => c.Name).HasMaxLength(200).IsRequired();
            this.Property(c => c.Description).IsRequired();

            // Tables
            this.ToTable("Categories");
            this.Property(c => c.Description).HasColumnName("Descriptions");
        }

    }
}
