using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.OrderItemDtos;
using Webshop.DAL.AppDbContext;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _ctx;

        public OrdersRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Order> GetByCustomerId(int customerId)
        {
            DbOrder result = await _ctx.Orders.Include(O => O.Customer).Include(o => o.Items).ThenInclude(oi => oi.Product).Where(o => o.CustomerId == customerId).SingleOrDefaultAsync();
            if (result == null)
                return null;
            else
                return ToModel(result);
        }

        public async Task<Order> Create(int customerId)
        {
            var toInsert = new DbOrder() { CustomerId = customerId };
            await _ctx.Orders.AddAsync(toInsert);
            _ctx.SaveChanges();
            var result = await _ctx.Orders.Include(o => o.Customer).Include(o => o.Items).Where(o => o.Id == toInsert.Id).SingleOrDefaultAsync();
            return ToModel(result);
        }

        public async Task<Order> Delete(int orderId)
        {
            var order = await _ctx.Orders.Include(o => o.Customer).Include(o => o.Items).Where(o => o.Id == orderId).SingleOrDefaultAsync();
            if (order == null)
                return null;
            _ctx.Orders.Remove(order);
            _ctx.SaveChanges();
            return ToModel(order);
        }

        private static Order ToModel(DbOrder order)
        {
            return new Order(order);
        }
    }
}
