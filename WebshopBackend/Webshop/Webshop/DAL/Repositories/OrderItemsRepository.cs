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
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public OrderItemsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OrderItem> InsertOrUpdate(OrderItemDto oi, int orderId)
        {
            var product = await _ctx.Products.Where(p => p.Id == oi.ProductId).SingleOrDefaultAsync();
            if (product == null)
                return null;
            var order = await _ctx.Orders.Include(o => o.Items).Where(o => o.Id == orderId).SingleOrDefaultAsync();
            if (order == null)
                return null;
            var oitem = order.Items.Where(i => i.ProductId == oi.ProductId).SingleOrDefault();
            int id;
            if (oitem == null)
            {
                DbOrderItem toInsert = new DbOrderItem() { ProductId = oi.ProductId, OrderId = order.Id, Quantity = oi.Amount, Price = product.Price * oi.Amount };
                await _ctx.OrderItems.AddAsync(toInsert);
                _ctx.SaveChanges();
                id = toInsert.Id;
            }
            else
            {
                var toUpdate = await _ctx.OrderItems.Where(o => o.Id == oitem.Id).SingleOrDefaultAsync();
                toUpdate.Quantity = oi.Amount;
                toUpdate.Price = product.Price * oi.Amount;
                _ctx.SaveChanges();
                id = toUpdate.Id;
            }
            var result = await _ctx.OrderItems.Include(o => o.Product).Where(o => o.Id == id).SingleOrDefaultAsync();
            return ToModel(result);
        }

        public async Task<OrderItem> Delete(int orderItemId)
        {
            var orderItem = await _ctx.OrderItems.Include(o => o.Product).Where(o => o.Id == orderItemId).SingleOrDefaultAsync();
            if (orderItem == null)
                return null;
            _ctx.OrderItems.Remove(orderItem);
            _ctx.SaveChanges();
            return ToModel(orderItem);
        }

        private static OrderItem ToModel(DbOrderItem entity)
        {
            return new OrderItem(entity);
        }
    }
}
