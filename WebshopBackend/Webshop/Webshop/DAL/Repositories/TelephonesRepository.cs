using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Models;
using Webshop.RepositoryFiltering.Filters;

namespace Webshop.DAL.Repositories
{
    public class TelephonesRepository : ITelephonesRepository
    {
        private readonly ApplicationDbContext _ctx;

        public TelephonesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Telephone>> Get(TelephoneFilter filter)
        {
            var pb = filter.CreateExpression();
            var result = await _ctx.Telephones.Where(pb).ToListAsync();
            return result.Select(ToModel).ToList();

        }

        public async Task<Telephone> GetById(long id)
        {
            DbTelephone item = await _ctx.Telephones.Where(h => h.Id == id).SingleOrDefaultAsync();
            if (item == null) return null;
            return ToModel(item);
        }

        public static Telephone ToModel(DbTelephone entity)
        {
            return new Telephone(entity);
        }
    }
}
