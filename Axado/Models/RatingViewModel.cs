using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axado.Models
{
    public class RatingViewModel
    {
        public int CarrierId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}