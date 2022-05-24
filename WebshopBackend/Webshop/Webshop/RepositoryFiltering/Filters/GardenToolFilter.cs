using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.DAL.AppDbContext;
using Webshop.RepositoryFilters;

namespace Webshop.RepositoryFiltering.Filters
{
    public class GardenToolFilter : ProductFilter
    {

        public GardenToolFilter() : base() { }

        public GardenToolFilter(GardenToolFilterDto dto) : base(dto) { }

        public new ExpressionStarter<DbGardenTool> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<DbGardenTool>();
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price <= p.LsThan) && (p.GtThan == null || p.GtThan <= h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<DbGardenTool>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer == m.Value);
            }

            return pbPrice.And(pbManufacturer);
        }
    }
}
