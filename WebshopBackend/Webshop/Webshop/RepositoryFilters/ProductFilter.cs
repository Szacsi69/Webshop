using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.RepositoryFilters
{
    public class ProductFilter
    {

        public ProductFilter()
        {
            Prices = new List<IntervalCondition>();
            Manufacturers = new List<EqualityCondition>();
        }

        public List<IntervalCondition> Prices { get; set; }
        public List<EqualityCondition> Manufacturers { get; set; }


        public ExpressionStarter<Product> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<Product>();
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price < p.LsThan) && (p.GtThan == null || p.GtThan < h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<Product>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer.ToLower() == m.Value);
            }

            return pbPrice.And(pbManufacturer);
        }
    }
}
