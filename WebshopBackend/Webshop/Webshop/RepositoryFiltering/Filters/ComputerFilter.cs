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
    public class ComputerFilter : ProductFilter
    {
        public ComputerFilter() : base()
        {
            Processors = new List<EqualityCondition>();
            GraphicsCards = new List<EqualityCondition>();
            HardDrives = new List<EqualityCondition>();
            Batteries = new List<EqualityCondition>();
        }

        public ComputerFilter(ComputerFilterDto dto) : base(dto)
        {
            Processors = new List<EqualityCondition>();
            GraphicsCards = new List<EqualityCondition>();
            HardDrives = new List<EqualityCondition>();
            Batteries = new List<EqualityCondition>();

            foreach (var s in dto.Processor)
            {
                Processors.Add(ExtractEqualityCondition(s));
            }
            foreach (var s in dto.GraphicsCard)
            {
                GraphicsCards.Add(ExtractEqualityCondition(s));
            }
            foreach (var s in dto.HardDrive)
            {
                HardDrives.Add(ExtractEqualityCondition(s));
            }
            foreach (var s in dto.Battery)
            {
                Batteries.Add(ExtractEqualityCondition(s));
            }
        }

        public List<EqualityCondition> Processors { get; set; }
        public List<EqualityCondition> GraphicsCards { get; set; }
        public List<EqualityCondition> HardDrives { get; set; }
        public List<EqualityCondition> Batteries { get; set; }

        public new ExpressionStarter<DbComputer> CreateExpression()
        {
            var pbPrice = PredicateBuilder.New<DbComputer>(true);
            foreach (var p in Prices)
            {
                pbPrice.Or(h => (p.LsThan == null || h.Price <= p.LsThan) && (p.GtThan == null || p.GtThan <= h.Price));
            }
            var pbManufacturer = PredicateBuilder.New<DbComputer>(true);
            foreach (var m in Manufacturers)
            {
                pbManufacturer.Or(h => h.Manufacturer == m.Value);
            }

            var pbProcessor = PredicateBuilder.New<DbComputer>(true);
            foreach (var e in Processors)
            {
                pbProcessor.Or(h => h.Processor == e.Value);
            }
            var pbGraphicsCard = PredicateBuilder.New<DbComputer>(true);
            foreach (var e in GraphicsCards)
            {
                pbGraphicsCard.Or(h => h.GraphicsCard == e.Value);
            }
            var pbHardDrive = PredicateBuilder.New<DbComputer>(true);
            foreach (var e in HardDrives)
            {
                pbHardDrive.Or(h => h.HardDrive == e.Value);
            }
            var pbBattery = PredicateBuilder.New<DbComputer>(true);
            foreach (var e in Batteries)
            {
                pbBattery.Or(h => h.Battery == e.Value);
            }


            var pb = pbPrice.And(pbManufacturer).And(pbProcessor).And(pbGraphicsCard).And(pbHardDrive).And(pbBattery);
            return pb;
        }
    }
}
