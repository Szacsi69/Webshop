using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.RepositoryFilters
{
    public class IntervalCondition
    {

        public IntervalCondition() 
        {
            GtThan = null;
            LsThan = null;
        }
        public IntervalCondition(int gt, int ls)
        {
            GtThan = gt;
            LsThan = ls;
        }

        public int? GtThan { get; set; }
        public int? LsThan { get; set; }
    }
}
