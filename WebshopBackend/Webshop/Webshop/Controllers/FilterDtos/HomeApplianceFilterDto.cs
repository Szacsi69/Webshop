using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Controllers.FilterDtos
{
    public class HomeApplianceFilterDto : ProductFilterDto
    {
        public HomeApplianceFilterDto() : base() {
            EnergyClass = new string[] { };
            CubicCapacity = new string[] { };
        }

        public string[] EnergyClass { get; set; }
        public string[] CubicCapacity { get; set; }
    }
}
