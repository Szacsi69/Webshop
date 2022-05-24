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
    public class ComputersRepository : IComputersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ComputersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Computer>> Get(ComputerFilter filter)
        {
            var pb = filter.CreateExpression();
            var result = await _ctx.Computers.Where(pb).ToListAsync();
            return result.Select(ToModel).ToList();

        }

        public async Task<Computer> GetById(long id)
        {
            DbComputer item = await _ctx.Computers.Where(h => h.Id == id).SingleOrDefaultAsync();
            if (item == null) return null;
            return ToModel(item);
        }

        public static Computer ToModel(DbComputer entity)
        {
            return new Computer(entity);
        }
    }
}

