using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Data.Models
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string District { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
