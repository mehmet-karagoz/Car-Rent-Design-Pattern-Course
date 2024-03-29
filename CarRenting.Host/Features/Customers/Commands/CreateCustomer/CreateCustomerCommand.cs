﻿using CarRenting.Host.Common;
using CarRenting.Host.Entities;
using CarRenting.Host.Interfaces;
using Entities;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace CarRenting.Host.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        private readonly CarRentalSystem _carRentalSystem;


        public CreateCustomerCommand(string name, string email, string phone, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            _carRentalSystem = CarRentalSystem.Instance;

        }

        public Response<int> Execute()
        {
            // Create a new car with the specified make, model, and year
            Customer customer = new Customer
            {
                Id = _carRentalSystem.GetCustomers().Any() ? _carRentalSystem.GetCustomers().Last().Id + 1 : 0,
                Name = Name,
            Email = Email,
            Phone = Phone,
            Address = Address,
        };
            // Add the new car to the car rental system
            _carRentalSystem.AddCustomer(customer);

            return new Response<int>(customer.Id);
        }
    }
}
