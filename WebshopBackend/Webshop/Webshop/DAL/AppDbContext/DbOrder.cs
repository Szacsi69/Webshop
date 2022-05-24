using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DAL.AppDbContext
{
    public class DbOrder
    {

        public DbOrder()
        {
            Items = new List<DbOrderItem>();
        }

        [Key]
        public int Id { get; set; }

        public DbCustomer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<DbOrderItem> Items { get; set; }
    }
}
