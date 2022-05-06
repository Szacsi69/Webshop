using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public OrderStatusCode OrderStatusCode { get; set; }
    }
}
