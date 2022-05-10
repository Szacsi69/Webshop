using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Filters
{
    public class ShopFilterFactory
    {
        public static List<ShopFilter> GetHomeApplianceFilters(List<HomeAppliance> items)
        {
            List<ShopFilter> filters = new();
            ShopFilter price = new ShopFilter("price", true);
            ShopFilter manufacturer = new ShopFilter("manufacturer");

            ShopFilter energyClass = new ShopFilter("energyClass");
            ShopFilter cubicCapacity = new ShopFilter("cubicCapacity", true);
            filters.Add(price);
            filters.Add(manufacturer);

            filters.Add(energyClass);
            filters.Add(cubicCapacity);

            List<int> prices = new List<int>();
            List<int?> cubicCapacities = new List<int?>();
            foreach (var i in items)
            {
                   
                prices.Add(i.Price);

                if (i.Manufacturer != null && !manufacturer.Values.Contains(i.Manufacturer))
                    manufacturer.Values.Add(i.Manufacturer);

                if(i.EnergyClass != "-" && !energyClass.Values.Contains(i.EnergyClass))
                    energyClass.Values.Add(i.EnergyClass);

                if (i.CubicCapacity != null)
                    cubicCapacities.Add(i.CubicCapacity);   
            }
            prices = prices.OrderBy(p => p).ToList();
            cubicCapacities = cubicCapacities.OrderBy(c => c).ToList();

            List<int?> tresholds = new List<int?>();
            tresholds.Add(prices[prices.Count / 3]);
            tresholds.Add(prices[2 * prices.Count / 3]);

            price.Values.Add(tresholds[0].ToString());
            price.Values.Add(tresholds[1].ToString());

            tresholds = new List<int?>();
            tresholds.Add(cubicCapacities[cubicCapacities.Count / 3]);
            tresholds.Add(cubicCapacities[2 * cubicCapacities.Count / 3]);

            cubicCapacity.Values.Add(tresholds[0].ToString());
            cubicCapacity.Values.Add(tresholds[1].ToString());

            return filters;
        }
    }
}
