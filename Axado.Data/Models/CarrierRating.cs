using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Data.Models
{
    public class CarrierRating : BaseEntity
    {
        public int CarrierId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

        public virtual User User { get; set; }
    }
}
