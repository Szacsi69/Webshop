using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Controllers.FilterDtos
{
    public class ComputerFilterDto : ProductFilterDto
    {
        public ComputerFilterDto() : base() 
        {
            Processor = new string[] { };
            GraphicsCard = new string[] { };
            HardDrive = new string[] { };
            Battery = new string[] { };
        }

        public string[] Processor { get; set; }
        public string[] GraphicsCard { get; set; }
        public string[] HardDrive { get; set; }
        public string[] Battery { get; set; }
    }
}
