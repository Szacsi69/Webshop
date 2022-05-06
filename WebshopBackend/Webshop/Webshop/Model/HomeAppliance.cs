using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class HomeAppliance : Product
    {
        public string EnergyClass { get; set; }
        public int? CubicCapacity { get; set; }
    }
}
