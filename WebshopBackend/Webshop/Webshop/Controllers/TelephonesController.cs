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
    [Route("shop/telephones")]
    [ApiController]
    public class TelephonesController : ControllerBase
    {
        private readonly ITelephonesRepository _repository;

        public TelephonesController(ITelephonesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Telephone>>> GetTelephonesThroughFilters([FromBody] TelephoneFilterDto filterDto)
        {
            var filter = new TelephoneFilter(filterDto);
            var items = await _repository.Get(filter);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Telephone>> GetTelephoneById(long id)
        {
            var item = await _repository.GetById(id);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShopFilter>>> GetTelephones()
        {
            var items = await _repository.Get(new TelephoneFilter());
            var filters = ShopFilterFactory.GetTelephoneFilters(items);
            return Ok(new { Products = items, Filters = filters });
        }
    }
}
