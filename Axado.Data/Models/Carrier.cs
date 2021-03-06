﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Data.Models
{
    public class Carrier : BaseEntity
    {
        public Carrier()
            : base()
        {
            this.Address = new Address();
            this.Ratings = new List<CarrierRating>();
        }


        public string Name { get; set; }
        public string Code { get; set; }
        public string Identification { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Url { get; set; }
        public decimal PricePerKm { get; set; }
        public TimeSpan? PickUpTime { get; set; }

        public virtual ICollection<CarrierRating> Ratings { get; set; }
    }
}
