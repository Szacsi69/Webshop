using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Controllers.OrderItemDtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
