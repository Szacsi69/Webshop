using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public int Value { get; set; }
    }
}
