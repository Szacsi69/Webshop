using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Models;
using Webshop.RepositoryFilters;

namespace Webshop.DAL.Repositories
{
    public class HomeAppliancesRepository : IHomeAppliancesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public HomeAppliancesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<HomeAppliance>> Get(HomeApplianceFilter filter)
        {
            var pb = filter.CreateExpression();
            var result = await _ctx.HomeAppliances.Where(pb).ToListAsync();
            return result.Select(ToModel).ToList();
            
        }

        public async Task<HomeAppliance> GetById(long id)
        {
            DbHomeAppliance item = await _ctx.HomeAppliances.Where(h => h.Id == id).SingleOrDefaultAsync();
            if (item == null) return null;
            return ToModel(item);
        }

        public static HomeAppliance ToModel(DbHomeAppliance entity) {
            return new HomeAppliance(entity);
        }
    }
}
