using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Data.Models;

namespace Axado.Persistence.Mapping
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap()
        {
            // Colunas especificas
            this.Property(t => t.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            this.Property(t => t.Picture)
                .HasColumnName("picture")
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsOptional();
        }
    }
}
