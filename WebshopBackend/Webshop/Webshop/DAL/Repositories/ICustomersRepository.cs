using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Authentication.Dtos;
using Webshop.Dtos;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public interface ICustomersRepository
    {
        public Task<Customer> Insert(RegisterDto value);
        public Task<Customer> GetByUserName(string username);
        public Task<Customer> GetById(int id);
        public Task<Customer> Update(CustomerDto value, int id);
        public Task<Customer> GetByEmail(string email);
    }
}
