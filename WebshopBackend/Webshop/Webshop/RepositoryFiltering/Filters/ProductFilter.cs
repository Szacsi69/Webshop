using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.DAL.AppDbContext;
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

        public ProductFilter(ProductFilterDto dto)
        {
            Prices = new List<IntervalCondition>();
            Manufacturers = new List<EqualityCondition>();

            foreach (var s in dto.Price)
            {
                Prices.Add(ExtractIntervalCondition(s));
            }

            foreach (var s in dto.Manufacturer)
            {
                Manufacturers.Add(ExtractEqualityCondition(s));
            }
        }
        public List<IntervalCondition> Prices { get; set; }
        public List<EqualityCondition> Manufacturers { get; set; }



        public ExpressionStarter<DbProduct> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<DbProduct>();
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price <= p.LsThan) && (p.GtThan == null || p.GtThan <= h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<DbProduct>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer == m.Value);
            }

            return pbPrice.And(pbManufacturer);
        }

        protected IntervalCondition ExtractIntervalCondition(string query)
        {
            IntervalCondition ic = new IntervalCondition();
            string[] conditions = query.Split(":");
            foreach (var s in conditions)
            {
                string[] values = s.Split("-");
                if (values[0] == "ls")
                    ic.LsThan = Int32.Parse(values[1]);
                else if (values[0] == "gt")
                    ic.GtThan = Int32.Parse(values[1]);
            }
            return ic;
        }

        protected EqualityCondition ExtractEqualityCondition(string query)
        {
            return new EqualityCondition(query);
        }
    }
}
