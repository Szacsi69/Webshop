using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Webshop.Filters;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.RepositoryFilters;

namespace Webshop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IWebshopRepository _repository;

        public ShopController(IWebshopRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("homeappliances")]
        public async Task<ActionResult<List<HomeAppliance>>> GetHomeAppliances([FromQuery(Name = "price")] string[] prices = null, [FromQuery(Name = "manufacturer")] string[] manufacturers = null, [FromQuery(Name = "energyClass")] string[] energyClasses = null, [FromQuery(Name = "cubicCapacity")] string[] cubicCapacities = null)
        {
            var filter = RepositoryFilterFactory.CreateHomeApplianceFilter(prices, manufacturers, energyClasses, cubicCapacities);
            var items = await _repository.GetHomeAppliances(filter);
            return Ok(items);
        }

        [HttpGet("homeappliances/{id}")]
        public async Task<ActionResult<HomeAppliance>> GetHomeApplianceById(long id)
        {
            var item = await _repository.GetHomeApplianceById(id);
            return Ok(item);
        }

        [HttpGet("filters/homeappliances")]
        public async Task<ActionResult<List<ShopFilter>>> GetHomeApplianceFilters()
        {
            var items = await _repository.GetHomeAppliances(new HomeApplianceFilter());
            var filters = ShopFilterFactory.GetHomeApplianceFilters(items);
            return Ok(filters);
        }
    }
}
