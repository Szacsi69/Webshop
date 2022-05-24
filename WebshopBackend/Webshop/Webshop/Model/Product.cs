using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class Product
    {
        public Product() { }

        public Product(int _id, string _name, int _price, string _imagePath, string _size, string _color, string _manufacturer, string _description, string _status, int _amount)
        {
            Id = _id;
            Name = _name;
            Price = _price;
            ImagePath = _imagePath;
            Size = _size;
            Color = _color;
            Manufacturer = _manufacturer;
            Description = _description;
            Status = _status;
            Amount = _amount;
        }

        public Product(DbProduct entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Price = entity.Price;
            ImagePath = entity.ImagePath;
            Size = entity.Size;
            Color = entity.Color;
            Manufacturer = entity.Manufacturer;
            Description = entity.Description;
            Status = entity.Status;
            Amount = entity.Amount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }
    }
}
