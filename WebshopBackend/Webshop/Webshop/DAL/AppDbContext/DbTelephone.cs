using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.DAL.AppDbContext
{
    public class DbTelephone : DbProduct
    {
        public string OperatingSystem { get; set; }
        public string Sim { get; set; }
    }
}
