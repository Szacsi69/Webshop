using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Data;
using Webshop.Models;

namespace Webshop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CustomerRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Customer CreateCustomer(Customer c)
        {
             _ctx.Customers.AddAsync(c);
            _ctx.SaveChanges();
            return c;
        }

        public Customer GetByLoginName(string loginname)
        {
            return _ctx.Customers.FirstOrDefault(c => c.LoginName == loginname);
        }

        public Customer GetByEmail(string email)
        {
            return _ctx.Customers.FirstOrDefault(c => c.EmailAddress == email);
        }

        public Customer GetById(int id)
        {
            return _ctx.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer newCustomer)
        {
            var customer = _ctx.Customers.FirstOrDefault(c => c.Id == newCustomer.Id);
            if (customer != null)
            {
                _ctx.Entry(customer).CurrentValues.SetValues(newCustomer);
                _ctx.SaveChanges();
            }
            return customer;
        }
    }
}
