using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.RepositoryFilters
{
    public class EqualityCondition
    {

        public EqualityCondition(string _value)
        {
            Value = _value;
        }

        public string Value { get; set; }
    }
}
