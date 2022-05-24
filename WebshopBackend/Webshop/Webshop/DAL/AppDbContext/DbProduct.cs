using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.DAL.AppDbContext
{
    public class DbProduct
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }
    }
}
