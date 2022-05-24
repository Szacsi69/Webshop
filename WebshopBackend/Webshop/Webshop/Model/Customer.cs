using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Webshop.DAL.AppDbContext;

namespace Webshop.Models
{
    public class Customer
    {
        public Customer() { }

        public Customer(int _id, string _username, string _email)
        {
            Id = _id;
            UserName = _username;
            Email = _email;
        }

        public Customer (int _id, string _fullname, string _gender, string _username, string _password, string _email, string _phonenumber, string _addressline, string _city, string _county, string _country)
        {
            Id = _id;
            FullName = _fullname;
            Gender = _gender;
            UserName = _username;
            Password = _password;
            Email = _email;
            PhoneNumber = _phonenumber;
            AddressLine = _addressline;
            City = _city;
            County = _county;
            Country = _country;
        }

        public Customer(DbCustomer entity)
        {
            Id = entity.Id;
            FullName = entity.FullName;
            Gender = entity.Gender;
            UserName = entity.UserName;
            Password = entity.Password;
            Email = entity.Email;
            PhoneNumber = entity.PhoneNumber;
            AddressLine = entity.AddressLine;
            City = entity.City;
            County = entity.County;
            Country = entity.Country;
        }
        
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
