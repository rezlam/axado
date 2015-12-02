using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axado.Areas.Admin.Models
{
    public class CarrierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Identification { get; set; }
        public string StreetAddress { get; set; }
        public string District { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PhoneNumber { get; set; }
        public string Url { get; set; }
        public decimal PricePerKm { get; set; }
        public TimeSpan? PickUpTime { get; set; }
    }
}