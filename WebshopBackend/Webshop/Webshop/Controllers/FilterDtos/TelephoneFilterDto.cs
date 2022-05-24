using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Controllers.FilterDtos
{
    public class TelephoneFilterDto : ProductFilterDto
    {
        public TelephoneFilterDto() : base()
        {
            Sim = new string[] { };
            OpSys = new string[] { };
        }

        public string[] Sim { get; set; }
        public string[] OpSys { get; set; }
    }
}
