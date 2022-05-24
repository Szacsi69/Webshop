using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public interface IOrdersRepository
    {
        public Task<Order> GetByCustomerId(int customerId);
        public Task<Order> Create(int customerId);
        public Task<Order> Delete(int orderId);
    }
}
