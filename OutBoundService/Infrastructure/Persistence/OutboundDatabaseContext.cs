using Microsoft.EntityFrameworkCore;
using OutBoundService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Persistence
{
    public class OutboundDatabaseContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Truck> Truck { get; set; }
        public DbSet<OrderCustomer> OrderCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-V0EIS4KM;Initial Catalog=warehouse_demo;Integrated Security=True");
        }

    }
}
