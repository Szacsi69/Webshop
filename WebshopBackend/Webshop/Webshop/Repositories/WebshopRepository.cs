using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data;
using Webshop.Models;
using Webshop.RepositoryFilters;

namespace Webshop.Repositories
{
    public class WebshopRepository : IWebshopRepository
    {
        private readonly ApplicationDbContext _ctx;

        public WebshopRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<HomeAppliance>> GetHomeAppliances(HomeApplianceFilter filter)
        {
            var pb = filter.CreateExpression();

            return await _ctx.HomeAppliances.Where(pb).ToListAsync();
        }

        public async Task<HomeAppliance> GetHomeApplianceById(long id)
        {
            return await _ctx.HomeAppliances.Where(h => h.Id == id).SingleAsync();
        }
    }
}
