using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.DAL.AppDbContext;
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

        public HomeApplianceFilter(HomeApplianceFilterDto dto) : base(dto)
        {
            EnergyClasses = new List<EqualityCondition>();
            CubicCapacities = new List<IntervalCondition>();

            foreach (var s in dto.EnergyClass)
            {
                EnergyClasses.Add(ExtractEqualityCondition(s));
            }

            foreach (var s in dto.CubicCapacity)
            {
                CubicCapacities.Add(ExtractIntervalCondition(s));
            }
        }

        public List<EqualityCondition> EnergyClasses { get; set; }
        public List<IntervalCondition> CubicCapacities { get; set; }


        public new ExpressionStarter<DbHomeAppliance> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<DbHomeAppliance>(true);
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price <= p.LsThan) && (p.GtThan == null || p.GtThan <= h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<DbHomeAppliance>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer == m.Value);
            }

            var pbEnergyClass = PredicateBuilder.New<DbHomeAppliance>(true);
            foreach (var e in EnergyClasses)
            {
                pbEnergyClass.Or(h => h.EnergyClass == e.Value);
            }
            var pbCubicCapacity = PredicateBuilder.New<DbHomeAppliance>(true);
            foreach (var c in CubicCapacities)
            {
                pbCubicCapacity.Or(h => (c.LsThan == null || h.CubicCapacity < c.LsThan) && (c.GtThan == null || c.GtThan < h.CubicCapacity));
            }

            var pb = pbPrice.And(pbManufacturer).And(pbEnergyClass).And(pbCubicCapacity);
            return pb;
        }
    }
}
