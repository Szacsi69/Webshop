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
    public class TelephoneFilter : ProductFilter
    {
        public TelephoneFilter() : base()
        {
            Sims = new List<EqualityCondition>();
            OperatingSystems = new List<EqualityCondition>();
        }

        public TelephoneFilter(TelephoneFilterDto dto) : base(dto)
        {
            Sims = new List<EqualityCondition>();
            OperatingSystems = new List<EqualityCondition>();

            foreach (var s in dto.Sim)
            {
                Sims.Add(ExtractEqualityCondition(s));
            }

            foreach (var s in dto.OpSys)
            {
                OperatingSystems.Add(ExtractEqualityCondition(s));
            }
        }

        public List<EqualityCondition> Sims { get; set; }
        public List<EqualityCondition> OperatingSystems { get; set; }


        public new ExpressionStarter<DbTelephone> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<DbTelephone>(true);
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price <= p.LsThan) && (p.GtThan == null || p.GtThan <= h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<DbTelephone>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer == m.Value);
            }

            var pbSim = PredicateBuilder.New<DbTelephone>(true);
            foreach (var e in Sims)
            {
                pbSim.Or(h => h.Sim == e.Value);
            }
            var pbOpSys = PredicateBuilder.New<DbTelephone>(true);
            foreach (var e in OperatingSystems)
            {
                pbOpSys.Or(h => h.OperatingSystem == e.Value);
            }

            var pb = pbPrice.And(pbManufacturer).And(pbSim).And(pbOpSys);
            return pb;
        }
    }
}
