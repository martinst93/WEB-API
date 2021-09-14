using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;
using Test.Models.Enums;

namespace Test
{
    public static class CacheDb
    {
        public static int PizzaId = 2;
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                NameOfPizza = "Italiana",
                Description = "Pizza Italiana",
                CustomerId = 1,
                PizzaSize = PizzaSize.Medium
            },
             new Pizza
            {
                Id = 2,
                NameOfPizza = "Peperoni",
                Description = "Peperoni Italiana",
                CustomerId = 2,
                PizzaSize = PizzaSize.Large
            },
        };

        public static int UserId = 2;
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Peter",
                OrderId = 1
            },
            new Customer
            {
                Id = 2,
                Name = "Robin",
                OrderId = 2
            },
        };
    }
}
