using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL.AppDbContext;
using Webshop.Models;
using Webshop.Dtos;
using Webshop.Authentication.Dtos;

namespace Webshop.DAL.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CustomersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Customer> Insert(RegisterDto value)
        {
            var userNameCheck = await _ctx.Customers.Where(c => c.UserName == value.UserName).SingleOrDefaultAsync();
            if (userNameCheck != null)
            {
                throw new ArgumentException("Ezzel a felhasználónévvel már létezik fiók!");
            }
            var emailNameCheck = await _ctx.Customers.Where(c => c.Email == value.Email).SingleOrDefaultAsync();
            if (emailNameCheck != null)
            {
                throw new ArgumentException("Ezzel az email címmel már létezik fiók!");
            }
            var toInsert = new DbCustomer() { UserName = value.UserName, Email = value.Email, Password = value.Password };
            await _ctx.Customers.AddAsync(toInsert);
            _ctx.SaveChanges();
            return ToModel(toInsert);
        }

        public async Task<Customer> GetByUserName(string username)
        {
            DbCustomer result = await _ctx.Customers.Where(c => c.UserName == username).SingleOrDefaultAsync();
            if (result == null)
                return null;
            else
                return ToModel(result);
        }

        public async Task<Customer> GetByEmail(string email)
        {
            DbCustomer result = await _ctx.Customers.Where(c => c.Email == email).SingleOrDefaultAsync();
            if (result == null)
                return null;
            else
                return ToModel(result);
        }

        public async Task<Customer> GetById(int id)
        {
            DbCustomer result =  await _ctx.Customers.Where(c => c.Id == id).SingleOrDefaultAsync();
            if (result == null)
                return null;
            else
                return ToModel(result);
        }

        public async Task<Customer> Update(CustomerDto value, int id)
        {
            var customer = await _ctx.Customers.Where(c => c.Id == id).SingleOrDefaultAsync();
            if (customer != null)
            {
                customer.FullName = value.FullName;
                customer.Gender = value.Gender;
                customer.Email = value.Email;
                customer.PhoneNumber = value.PhoneNumber;
                customer.AddressLine = value.Address;
                customer.City = value.City;
                customer.County = value.County;
                customer.Country = value.Country;
                _ctx.SaveChanges();
            }
            return ToModel(customer);
        }

        public static Customer ToModel(DbCustomer entity)
        {
            return new Customer(entity);
        }
    }
}
