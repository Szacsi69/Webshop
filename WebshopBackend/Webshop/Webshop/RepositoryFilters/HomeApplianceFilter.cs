using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.RepositoryFilters
{
    public class HomeApplianceFilter : ProductFilter
    {

        public HomeApplianceFilter() : base()
        {
            EnergyClasses = new List<EqualityCondition>();
            CubicCapacities = new List<IntervalCondition>();
        }

        public List<EqualityCondition> EnergyClasses { get; set; }
        public List<IntervalCondition> CubicCapacities { get; set; }


        public new ExpressionStarter<HomeAppliance> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<HomeAppliance>(true);
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price < p.LsThan) && (p.GtThan == null || p.GtThan < h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<HomeAppliance>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer.ToLower() == m.Value);
            }

            var pbEnergyClass = PredicateBuilder.New<HomeAppliance>(true);
            foreach (var e in EnergyClasses)
            {
                pbEnergyClass.Or(h => h.EnergyClass.ToLower() == e.Value);
            }
            var pbCubicCapacity = PredicateBuilder.New<HomeAppliance>(true);
            foreach (var c in CubicCapacities)
            {
                pbCubicCapacity.Or(h => (c.LsThan == null || h.CubicCapacity < c.LsThan) && (c.GtThan == null || c.GtThan < h.CubicCapacity));
            }

            var pb = pbPrice.And(pbManufacturer).And(pbEnergyClass).And(pbCubicCapacity);
            return pb;
        }
    }
}
