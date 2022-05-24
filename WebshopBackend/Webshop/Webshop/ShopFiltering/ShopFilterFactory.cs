using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Webshop.Model;
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

                if (i.CubicCapacity != -1)
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

        public static List<ShopFilter> GetComputerFilters(List<Computer> items)
        {
            List<ShopFilter> filters = new();
            ShopFilter price = new ShopFilter("price", true);
            ShopFilter manufacturer = new ShopFilter("manufacturer");

            ShopFilter processor = new ShopFilter("processor");
            ShopFilter graphicsCard = new ShopFilter("graphicsCard");
            ShopFilter harddrive = new ShopFilter("harddrive");
            ShopFilter battery = new ShopFilter("battery");
            filters.Add(price);
            filters.Add(manufacturer);

            filters.Add(processor);
            filters.Add(graphicsCard);
            filters.Add(harddrive);
            filters.Add(battery);

            List<int> prices = new List<int>();

            foreach (var i in items)
            {

                prices.Add(i.Price);

                if (i.Manufacturer != null && !manufacturer.Values.Contains(i.Manufacturer))
                    manufacturer.Values.Add(i.Manufacturer);

                if (i.Processor != "-" && !processor.Values.Contains(i.Processor))
                    processor.Values.Add(i.Processor);
                if (i.GraphicsCard != "-" && !graphicsCard.Values.Contains(i.GraphicsCard))
                    graphicsCard.Values.Add(i.GraphicsCard);
                if (i.HardDrive != "-" && !harddrive.Values.Contains(i.HardDrive))
                    harddrive.Values.Add(i.HardDrive);
                if (i.Battery != "-" && !battery.Values.Contains(i.Battery))
                    battery.Values.Add(i.Battery);

            }

            prices = prices.OrderBy(p => p).ToList();

            List<int?> tresholds = new List<int?>();
            tresholds.Add(prices[prices.Count / 3]);
            tresholds.Add(prices[2 * prices.Count / 3]);
            price.Values.Add(tresholds[0].ToString());
            price.Values.Add(tresholds[1].ToString());

            return filters;
        }

        public static List<ShopFilter> GetTelephoneFilters(List<Telephone> items)
        {
            List<ShopFilter> filters = new();
            ShopFilter price = new ShopFilter("price", true);
            ShopFilter manufacturer = new ShopFilter("manufacturer");

            ShopFilter sim = new ShopFilter("sim");
            ShopFilter opSys = new ShopFilter("opSys");
            filters.Add(price);
            filters.Add(manufacturer);

            filters.Add(sim);
            filters.Add(opSys);

            List<int> prices = new List<int>();

            foreach (var i in items)
            {

                prices.Add(i.Price);

                if (i.Manufacturer != null && !manufacturer.Values.Contains(i.Manufacturer))
                    manufacturer.Values.Add(i.Manufacturer);

                if (i.Sim != "-" && !sim.Values.Contains(i.Sim))
                    sim.Values.Add(i.Sim);
                if (i.OperatingSystem != "-" && !opSys.Values.Contains(i.OperatingSystem))
                    opSys.Values.Add(i.OperatingSystem);

            }

            prices = prices.OrderBy(p => p).ToList();

            List<int?> tresholds = new List<int?>();
            tresholds.Add(prices[prices.Count / 3]);
            tresholds.Add(prices[2 * prices.Count / 3]);
            price.Values.Add(tresholds[0].ToString());
            price.Values.Add(tresholds[1].ToString());

            return filters;
        }

        public static List<ShopFilter> GetGardenToolFilters(List<GardenTool> items)
        {
            List<ShopFilter> filters = new();
            ShopFilter price = new ShopFilter("price", true);
            ShopFilter manufacturer = new ShopFilter("manufacturer");

            filters.Add(price);
            filters.Add(manufacturer);

            List<int> prices = new List<int>();

            foreach (var i in items)
            {

                prices.Add(i.Price);

                if (i.Manufacturer != null && !manufacturer.Values.Contains(i.Manufacturer))
                    manufacturer.Values.Add(i.Manufacturer);

            }

            prices = prices.OrderBy(p => p).ToList();

            List<int?> tresholds = new List<int?>();
            tresholds.Add(prices[prices.Count / 3]);
            tresholds.Add(prices[2 * prices.Count / 3]);
            price.Values.Add(tresholds[0].ToString());
            price.Values.Add(tresholds[1].ToString());

            return filters;
        }
    }
}
