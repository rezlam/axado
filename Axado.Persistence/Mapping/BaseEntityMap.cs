using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Data.Models;

namespace Axado.Persistence.Mapping
{
    public abstract class BaseEntityMap<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public BaseEntityMap()
        {
            // Primary key
            this.HasKey(t => t.Id);

            // Colunas padrão
            this.Property(t => t.Id)
                .HasColumnName("id");

            this.Property(t => t.Active)
                .HasColumnName("active")
                .IsRequired();

            this.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasPrecision(3)
                .IsRequired();

            this.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasPrecision(3)
                .IsOptional();

            this.Property(t => t.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime2")
                .HasPrecision(3)
                .IsOptional();
        }
    }
}
