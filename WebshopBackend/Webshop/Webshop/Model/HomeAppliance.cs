using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class HomeAppliance : Product
    {
        public HomeAppliance() { }

        public HomeAppliance(int _id, string _name, int _price, string _imagePath, string _size, string _color, string _manufacturer, string _description, string _status, int _amount,
                        string _energyClass, int _cubicCapacity) : base(_id, _name, _price, _imagePath, _size, _color, _manufacturer, _description, _status, _amount)
        {
            EnergyClass = _energyClass;
            CubicCapacity = _cubicCapacity;
        }

        public HomeAppliance(DbHomeAppliance entity) : base(entity)
        {
            EnergyClass = entity.EnergyClass;
            CubicCapacity = entity.CubicCapacity;
        }

        public string EnergyClass { get; set; }
        public int? CubicCapacity { get; set; }
    }
}
