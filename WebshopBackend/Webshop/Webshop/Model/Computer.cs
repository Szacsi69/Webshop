using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class Computer : Product
    {

        public Computer() { }

        public Computer(int _id, string _name, int _price, string _imagePath, string _size, string _color, string _manufacturer, string _description, string _status, int _amount,
                       string _processor, string _graphicsCards, string _hardDrive, string _battery ) : base(_id, _name, _price, _imagePath,  _size, _color, _manufacturer, _description, _status, _amount)
        {
            Processor = _processor;
            GraphicsCard = _graphicsCards;
            HardDrive = _hardDrive;
            Battery = _battery;
        }

        public Computer(DbComputer entity) : base(entity)
        {
            Processor = entity.Processor;
            GraphicsCard = entity.GraphicsCard;
            HardDrive = entity.HardDrive;
            Battery = entity.Battery;
        }

        public string Processor { get; set; }
        public string GraphicsCard { get; set; }
        public string HardDrive { get; set; }
        public string Battery { get; set; }
    }
}
