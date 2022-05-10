using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Filters
{
    public class ShopFilter
    {

        public ShopFilter(string _name)
        {
            Name = _name;
            Interval = false;
            Values = new List<string>();
        }

        public ShopFilter(string _name, bool _interval)
        {
            Name = _name;
            Interval = _interval;
            Values = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Values { get; set; }

        public bool Interval { get; set; }
    }
}
