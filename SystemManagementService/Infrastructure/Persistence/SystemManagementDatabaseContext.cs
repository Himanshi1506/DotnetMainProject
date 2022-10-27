using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Domain.Entities;

namespace SystemManagementService.Infrastructure.Persistence
{
    public class SystemManagementDatabaseContext: DbContext
    {
        public DbSet<Node> Node { get; set; }
        public DbSet<Pallet> Pallet { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-V0EIS4KM;Initial Catalog=warehouse_demo;Integrated Security=True");
        }
    }
}
