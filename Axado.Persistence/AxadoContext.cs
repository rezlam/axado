using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Data.Entities;
using Axado.Persistence.Mapping;

namespace Axado.Persistence
{
    public class AxadoContext : DbContext
    {
        public AxadoContext()
            : base("axado")
        {
            //
        }
    }
}
