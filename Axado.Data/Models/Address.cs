using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Data.Models
{
    [ComplexType]
    public class Address
    {
        public string StreetAddress { get; set; }
        public string District { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
    }
}
