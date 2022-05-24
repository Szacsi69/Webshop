using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Controllers.OrderItemDtos;
using Webshop.Models;

namespace Webshop.DAL.Repositories
{
    public interface IOrderItemsRepository
    {
        public Task<OrderItem> InsertOrUpdate(OrderItemDto oi, int orderId);
        public  Task<OrderItem> Delete(int orderItemId);
    }
}
