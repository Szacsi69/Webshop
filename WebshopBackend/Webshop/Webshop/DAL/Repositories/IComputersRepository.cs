using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.RepositoryFiltering.Filters;

namespace Webshop.DAL.Repositories
{
    public interface IComputersRepository
    {
        public Task<List<Computer>> Get(ComputerFilter filter);

        public Task<Computer> GetById(long id);
    }
}
