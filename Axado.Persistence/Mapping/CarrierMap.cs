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
    public class CarrierMap : BaseEntityMap<Carrier>
    {
        public CarrierMap()
        {
            // Colunas especificas
            this.Property(t => t.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_Carriers") { IsUnique = true }
                ));

            this.Property(t => t.Identification)
                .HasColumnName("identification")
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Url)
                .HasColumnName("url")
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsOptional();

            this.Property(t => t.PricePerKm)
                .HasColumnName("price_per_km")
                .HasColumnType("decimal")
                .HasPrecision(7, 3)
                .IsRequired();

            this.Property(t => t.PickUpTime)
                .HasColumnName("pickup_time")
                .HasColumnType("time")
                .HasPrecision(0)
                .IsOptional();

            // Foreign keys
            this.HasMany(t => t.Ratings);
        }
    }
}
