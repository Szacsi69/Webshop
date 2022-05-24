using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DAL.AppDbContext
{
    public class DbHomeAppliance : DbProduct
    {
        public string EnergyClass { get; set; }
        public int? CubicCapacity { get; set; }
    }
}
