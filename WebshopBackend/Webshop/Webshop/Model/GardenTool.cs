using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;
using Webshop.Models;

namespace Webshop.Model
{
    public class GardenTool : Product
    {
        public GardenTool() { }

        public GardenTool(int _id, string _name, int _price, string _imagePath, string _size, string _color, string _manufacturer, string _description, string _status, int _amount
                          ) : base(_id, _name, _price, _imagePath, _size, _color, _manufacturer, _description, _status, _amount)
        {
        }

        public GardenTool(DbGardenTool entity) : base(entity) { }

    }
}
