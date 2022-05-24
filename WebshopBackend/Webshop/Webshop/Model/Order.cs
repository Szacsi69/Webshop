using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class Order
    {
        public Order() { }

        public Order(DbOrder entity)
        {
            Id = entity.Id;
            Customer = new Customer(entity.Customer);
            Items = new List<OrderItem>();
            foreach(var o in entity.Items)
            {
                Items.Add(new OrderItem(o));
            }
        }

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
