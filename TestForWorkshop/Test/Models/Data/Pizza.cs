using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Enums;

namespace Test.Models.Data
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string NameOfPizza { get; set; }
        public int CustomerId { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
