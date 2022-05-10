using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Authentication;
using Webshop.Authentication.Dtos;
using Webshop.Dtos;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ICustomerRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(ICustomerRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_repository.GetByLoginName(dto.UserName) != null)
            {
                return BadRequest(new { message = "Ez a felhasználónévvel már létezik fiók!" });
            }

            if (_repository.GetByEmail(dto.Email) != null)
            {
                return BadRequest(new { message = "Ezzel az email címmel már létezik fiók!" });
            }
            var customer = new Customer
            {
                LoginName = dto.UserName,
                EmailAddress = dto.Email,
                LoginPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            var created = _repository.CreateCustomer(customer);
            return Created("success", created);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var customer = _repository.GetByLoginName(dto.UserName);
            if (customer == null) return BadRequest(new { message = "Érvénytelen felhasználónév vagy jelszó." });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, customer.LoginPassword))
                return BadRequest(new { message = "Érvénytelen felhasználónév vagy jelszó." });

            var jwt = _jwtService.Generate(customer.Id);
            Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new { message = "success" });
        }

        [HttpGet("customer")]
        public IActionResult Customer()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int customerId = Int32.Parse(token.Issuer);

                var customer = _repository.GetById(customerId);
                return Ok(customer);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpPost("save")]
        public IActionResult SaveCustomerData(CustomerDto dto)
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
            var customerOld = _repository.GetById(customerId);
            var customerNew = new Customer
            {
                Id = customerId,
                FullName = dto.FullName,
                Gender = dto.Gender,
                LoginName = customerOld.LoginName,
                LoginPassword = customerOld.LoginPassword,
                EmailAddress = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                AddressLine = dto.Address,
                Town_City = dto.City,
                County = dto.County,
                Country = dto.Country
            };
            var customer = _repository.UpdateCustomer(customerNew);
            return Ok(customer);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(key: "jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}
