using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(DbOrderItem entity)
        {
            Id = entity.Id;
            Product = new Product(entity.Product);
            Quantity = entity.Quantity;
            Price = entity.Price;
        }
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
