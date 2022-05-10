using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Repositories
{
    public interface ICustomerRepository
    {
        public Customer CreateCustomer(Customer c);

        public Customer GetByLoginName(string loginname);
        public Customer GetById(int id);
        public Customer UpdateCustomer(Customer newCustomer);
        public Customer GetByEmail(string email);
    }
}
