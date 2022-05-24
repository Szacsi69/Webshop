using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.DAL.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DbCustomer> Customers { get; set; }
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbOrderItem> OrderItems { get; set; }
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbComputer> Computers { get; set; }
        public DbSet<DbTelephone> Telephones { get; set; }
        public DbSet<DbHomeAppliance> HomeAppliances { get; set; }
        public DbSet<DbGardenTool> GardenTools { get; set; }
    }
}
