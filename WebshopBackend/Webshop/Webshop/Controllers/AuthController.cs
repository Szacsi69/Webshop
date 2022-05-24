using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Services;
using Webshop.Authentication.Dtos;
using Webshop.Dtos;
using Webshop.Models;
using Webshop.DAL.Repositories;

namespace Webshop.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ICustomersRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(ICustomersRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            try
            {
                var created = await _repository.Insert(dto);
                return Created("Success!", created);
            }
            catch (Exception e)
            {
               return BadRequest(new { error = e.Message });
            }
            
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var customer = await _repository.GetByUserName(dto.UserName);
            if (customer == null) return BadRequest(new { message = "Érvénytelen felhasználónév vagy jelszó." });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, customer.Password))
                return BadRequest(new { message = "Érvénytelen felhasználónév vagy jelszó." });

            var jwt = _jwtService.Generate(customer.Id);
            Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new { message = "Success!" });
        }

        [HttpGet("customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Customer()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int customerId = Int32.Parse(token.Issuer);

                var customer = await _repository.GetById(customerId);
                return Ok(customer);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SaveCustomerData(CustomerDto dto)
        {
            int customerId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                customerId = Int32.Parse(token.Issuer);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
            
            var customer = await _repository.Update(dto, customerId);
            return Ok(customer);
        }

        [HttpPost("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(key: "jwt");

            return Ok(new
            {
                message = "Success!"
            });
        }
    }
}
