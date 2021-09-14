using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;
using Test.Models.Dto;

namespace Test.Services.Interface
{
    public interface IPizzaService
    {
        List<PizzaDto> GetPizzas(int customerId);
        PizzaDto GetPizzaDetails(int pizzaId, int customerId);
        string AddPizza(PizzaDto pizza);
        string DeletePizza(int pizzaId, int userId);
        void UpdatePizza(PizzaDto pizza);
    }
}
