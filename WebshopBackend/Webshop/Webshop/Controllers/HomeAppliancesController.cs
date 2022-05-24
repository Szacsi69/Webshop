using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.Filters;
using Webshop.Models;
using Webshop.DAL.Repositories;
using Webshop.RepositoryFilters;

namespace Webshop.Controllers
{
    [Route("shop/homeappliances")]
    [ApiController]
    public class HomeAppliancesController : ControllerBase
    {
        private readonly IHomeAppliancesRepository _repository;

        public HomeAppliancesController(IHomeAppliancesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HomeAppliance>>> GetHomeAppliancesThroughFilters([FromBody] HomeApplianceFilterDto filterDto)
        {
            var filter = new HomeApplianceFilter(filterDto);
            var items = await _repository.Get(filter);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HomeAppliance>> GetHomeApplianceById(long id)
        {
            var item = await _repository.GetById(id);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShopFilter>>> GetHomeAppliances()
        {
            var items = await _repository.Get(new HomeApplianceFilter());
            var filters = ShopFilterFactory.GetHomeApplianceFilters(items);
            return Ok(new { Products = items, Filters = filters });
        }
    }
}
