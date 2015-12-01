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
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Colunas específicas
            this.Property(t => t.StreetAddress)
                .HasColumnName("streetaddress")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.District)
                .HasColumnName("district")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Locality)
                .HasColumnName("locality")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Region)
                .HasColumnName("region")
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Country)
                .HasColumnName("country")
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
