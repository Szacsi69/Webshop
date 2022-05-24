using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.FilterDtos;
using Webshop.DAL.Repositories;
using Webshop.Filters;
using Webshop.Models;
using Webshop.RepositoryFiltering.Filters;
using Webshop.RepositoryFilters;

namespace Webshop.Controllers
{
    [Route("shop/computers")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly IComputersRepository _repository;

        public ComputersController(IComputersRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Computer>>> GetComputersThroughFilters([FromBody] ComputerFilterDto filterDto)
        {
            var filter = new ComputerFilter(filterDto);
            var items = await _repository.Get(filter);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Computer>> GetComputerById(long id)
        {
            var item = await _repository.GetById(id);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShopFilter>>> GetComputers()
        {
            var items = await _repository.Get(new ComputerFilter());
            var filters = ShopFilterFactory.GetComputerFilters(items);
            return Ok(new { Products = items, Filters = filters });
        }
    }
}

