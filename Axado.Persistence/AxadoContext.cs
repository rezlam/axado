﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Data.Models;
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


        public DbSet<Carrier> Carriers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CarrierMap());
        }
    }
}
