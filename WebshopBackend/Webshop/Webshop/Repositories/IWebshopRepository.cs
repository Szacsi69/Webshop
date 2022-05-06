using System.Collections.Generic;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.RepositoryFilters;

namespace Webshop.Repositories
{
    public interface IWebshopRepository
    {
        public Task<List<HomeAppliance>> GetHomeAppliances(HomeApplianceFilter filter);

        public Task<HomeAppliance> GetHomeApplianceById(long id);
    }
}