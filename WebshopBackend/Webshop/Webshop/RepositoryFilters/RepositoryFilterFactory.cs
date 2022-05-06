using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.RepositoryFilters
{
    public class RepositoryFilterFactory
    {
        public static HomeApplianceFilter CreateHomeApplianceFilter(string[] prices, string[] manufacturers, string[] energyClasses, string[] cubicCapacities)
        {
            HomeApplianceFilter filter = new();
            foreach(var s in prices)
            {
                filter.Prices.Add(ExtractIntervalCondition(s));
            }

            foreach (var s in manufacturers)
            {
                filter.Manufacturers.Add(ExtractEqualityCondition(s));
            }

            foreach (var s in energyClasses)
            {
                filter.EnergyClasses.Add(ExtractEqualityCondition(s));
            }

            foreach (var s in cubicCapacities)
            {
                filter.CubicCapacities.Add(ExtractIntervalCondition(s));
            }
            return filter;
        }

        public static IntervalCondition ExtractIntervalCondition(string query)
        {
            IntervalCondition ic = new IntervalCondition();
            string[] conditions = query.Split(":");
            foreach(var s in conditions)
            {
                string[] values = s.Split("-");
                if (values[0] == "ls")
                    ic.LsThan = Int32.Parse(values[1]);
                else if (values[0] == "gt")
                    ic.GtThan = Int32.Parse(values[1]);
            }
            return ic;
        }

        public static EqualityCondition ExtractEqualityCondition(string query)
        {
            return new EqualityCondition(query);
        }
    }
}
