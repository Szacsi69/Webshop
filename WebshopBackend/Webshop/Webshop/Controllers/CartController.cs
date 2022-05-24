using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.OrderItemDtos;
using Webshop.DAL.Repositories;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly JwtService _jwtService;

        public CartController(IOrdersRepository orepository, IOrderItemsRepository oirepository, IProductsRepository prepository, JwtService jwtService)
        {
            _ordersRepository = orepository;
            _orderItemsRepository = oirepository;
            _productsRepository = prepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                int customerId = Authenticate(jwt);

                var order = await _ordersRepository.GetByCustomerId(customerId);
                if (order == null)
                    return NotFound();
                else
                    return Ok(order);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrUpdateCart([FromBody] OrderItemDto dto)
        {
            int customerId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                customerId = Authenticate(jwt);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
            var product = await _productsRepository.GetById(dto.ProductId);
            if (product == null)
                return BadRequest(new { message = "Nincs ilyen termék a shop-ban." });
            if (dto.Amount > product.Amount)
                return BadRequest(new { message = "A kért mennyiség nem áll rendelkezésre." });

            var order = await _ordersRepository.GetByCustomerId(customerId);
            if (order == null)
                order = await _ordersRepository.Create(customerId);
            
            var orderItem = await _orderItemsRepository.InsertOrUpdate(dto, order.Id);
            return Ok(orderItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            int customerId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                customerId = Authenticate(jwt);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }

            var orderItem = await _orderItemsRepository.Delete(id);
            if (orderItem == null)
                return NotFound();
            var order = await _ordersRepository.GetByCustomerId(customerId);
            if (order.Items.Count == 0)
                await _ordersRepository.Delete(order.Id);
            return NoContent();

        }

        [HttpPost("buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Buy()
        {
            int customerId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                customerId = Authenticate(jwt);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
            var order = await _ordersRepository.GetByCustomerId(customerId);
            if (order == null)
                return NotFound();
            var success = new List<int>();
            var failed = new List<int>();
            foreach (var oi in order.Items)
            {
                var p = await _productsRepository.RemoveProductItem(oi.Product.Id, oi.Quantity);
                if (p == null)
                    failed.Add(oi.Id);
                else
                    success.Add(oi.Id);
                await _orderItemsRepository.Delete(oi.Id);
            }
            await _ordersRepository.Delete(order.Id);
            return Ok(new { success = success, failed = failed });

        }

        private int Authenticate(string jwt)
        {
            var token = _jwtService.Verify(jwt);
            int customerId = Int32.Parse(token.Issuer);

            return customerId;
        }


    }
}
