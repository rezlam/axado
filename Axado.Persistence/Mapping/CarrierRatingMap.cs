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
    public class CarrierRatingMap : BaseEntityMap<CarrierRating>
    {
        public CarrierRatingMap()
        {
            // Colunas especificas
            this.Property(t => t.CarrierId)
                .HasColumnName("carrier_id")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_CarrierRatings") { IsUnique = true, Order = 1 }
                ));

            this.Property(t => t.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("ak_CarrierRatings") { IsUnique = true, Order = 2 }
                ));

            this.Property(t => t.Rating)
                .HasColumnName("rating")
                .IsRequired();

            // Foreign keys
            this.HasRequired(t => t.User);
        }
    }
}
