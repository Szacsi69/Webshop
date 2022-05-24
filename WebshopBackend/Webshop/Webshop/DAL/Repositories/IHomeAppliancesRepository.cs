using System.Collections.Generic;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.RepositoryFilters;

namespace Webshop.DAL.Repositories
{
    public interface IHomeAppliancesRepository
    {
        public Task<List<HomeAppliance>> Get(HomeApplianceFilter filter);

        public Task<HomeAppliance> GetById(long id);
    }
}