using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webshop.DAL.AppDbContext
{
    public class DbCustomer
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
