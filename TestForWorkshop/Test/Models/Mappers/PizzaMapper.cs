using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;
using Test.Models.Dto;
using Test.Models.Enums;

namespace Test.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDto PizzaModelToPizzaDto(Pizza pizza)
        {
            return new PizzaDto
            {
                Id = pizza.Id != 0 ? pizza.Id : 0,
                CustomerId = pizza.CustomerId,
                Description = pizza.Description,
                NameOfPizza = pizza.NameOfPizza,
                PizzaSize = (PizzaSize)pizza.PizzaSize
            };
        }

        public static Pizza PizzaDtoToPizzaModel(PizzaDto pizza)
        {
            return new Pizza
            {
                Id = pizza.Id !=0 ? pizza.Id : 0,
                CustomerId = pizza.CustomerId,
                Description = pizza.Description,
                NameOfPizza = pizza.NameOfPizza,
                PizzaSize = pizza.PizzaSize
            };
        }
    }
}
