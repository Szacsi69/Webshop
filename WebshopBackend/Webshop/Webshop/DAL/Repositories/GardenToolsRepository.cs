using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Model;
using Webshop.RepositoryFiltering.Filters;

namespace Webshop.DAL.Repositories
{
    public class GardenToolsRepository : IGardenToolsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public GardenToolsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<GardenTool>> Get(GardenToolFilter filter)
        {
            var pb = filter.CreateExpression();
            var result = await _ctx.GardenTools.Where(pb).ToListAsync();
            return result.Select(ToModel).ToList();

        }

        public async Task<GardenTool> GetById(long id)
        {
            DbGardenTool item = await _ctx.GardenTools.Where(h => h.Id == id).SingleOrDefaultAsync();
            if (item == null) return null;
            return ToModel(item);
        }

        public static GardenTool ToModel(DbGardenTool entity)
        {
            return new GardenTool(entity);
        }
    }
}
