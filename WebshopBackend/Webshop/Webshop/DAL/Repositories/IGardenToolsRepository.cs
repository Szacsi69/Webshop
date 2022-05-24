using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Model;
using Webshop.RepositoryFiltering.Filters;

namespace Webshop.DAL.Repositories
{
    public interface IGardenToolsRepository
    {
        public Task<List<GardenTool>> Get(GardenToolFilter filter);

        public Task<GardenTool> GetById(long id);
    }
}
