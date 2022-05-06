using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Computer : Product
    {
        public string Processor { get; set; }
        public string GraphicsCard { get; set; }
        public string HardDrive { get; set; }
        public string Battery { get; set; }
    }
}
