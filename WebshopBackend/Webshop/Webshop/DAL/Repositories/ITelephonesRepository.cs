using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.RepositoryFiltering.Filters;

namespace Webshop.DAL.Repositories
{
    public interface ITelephonesRepository
    {
        public Task<List<Telephone>> Get(TelephoneFilter filter);

        public Task<Telephone> GetById(long id);
    }
}
