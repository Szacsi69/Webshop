using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Controllers.FilterDtos
{
    public class ProductFilterDto
    {
        public ProductFilterDto()
        {
            Price = new string[] { };
            Manufacturer = new string[] { };
        }

        public string[] Price { get; set; }
        public string[] Manufacturer { get; set; }
    }
}
