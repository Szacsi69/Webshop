using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DAL.AppDbContext
{
    public class DbOrderItem
    {
        [Key]
        public int Id { get; set; }
        public DbProduct Product { get; set; }
        public int ProductId { get; set; }
        public DbOrder Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
