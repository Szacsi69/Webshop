using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.DAL.Repositories;
using Webshop.Filters;
using Webshop.Model;
using Webshop.RepositoryFiltering.Filters;
using Webshop.RepositoryFilters;

namespace Webshop.Controllers
{
    [Route("shop/tools")]
    [ApiController]
    public class GardenToolsController : ControllerBase
    {
        private readonly IGardenToolsRepository _repository;

        public GardenToolsController(IGardenToolsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GardenTool>>> GetGardenToolsThroughFilters([FromBody] GardenToolFilterDto filterDto)
        {
            var filter = new GardenToolFilter(filterDto);
            var items = await _repository.Get(filter);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GardenTool>> GetGardenToolById(long id)
        {
            var item = await _repository.GetById(id);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShopFilter>>> GetGardenTools()
        {
            var items = await _repository.Get(new GardenToolFilter());
            var filters = ShopFilterFactory.GetGardenToolFilters(items);
            return Ok(new { Products = items, Filters = filters });
        }
    }
}
