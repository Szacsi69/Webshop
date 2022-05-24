using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class Telephone : Product
    {
        public Telephone() { }

        public Telephone(int _id, string _name, int _price, string _imagePath, string _size, string _color, string _manufacturer, string _description, string _status, int _amount,
                        string _operatingSystem, string _sim) : base(_id, _name, _price, _imagePath, _size, _color, _manufacturer, _description, _status, _amount)
        {
            OperatingSystem = _operatingSystem;
            Sim = _sim;
        }

        public Telephone(DbTelephone entity) : base(entity)
        {
            OperatingSystem = entity.OperatingSystem;
            Sim = entity.Sim;
        }

        public string OperatingSystem { get; set; }
        public string Sim { get; set; }
    }
}
