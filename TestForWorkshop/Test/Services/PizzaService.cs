using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;
using Test.Models.Dto;
using Test.Models.Mappers;
using Test.Repository;
using Test.Services.Interface;

namespace Test.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public string AddPizza(PizzaDto pizza)
        {
            if (pizza.NameOfPizza == string.Empty)
            {
                throw new Exception("Name not found");
            }

            var pizzaModel = PizzaMapper.PizzaDtoToPizzaModel(pizza);

            _pizzaRepository.Add(pizzaModel);

            return "Pizza Succesfully added";
        }

        public string DeletePizza(int pizzaId, int userId)
        {
            var pizza = _pizzaRepository.GetAll().FirstOrDefault(x => x.Id == pizzaId && x.CustomerId == userId);

            if (pizza == null)
            {
                throw new Exception("Nothing was found");
            }

            _pizzaRepository.Delete(pizza);

            return "Pizza deleted succesfully";
        }

        public PizzaDto GetPizzaDetails(int pizzaId, int customerId)
        {
            var pizaa = _pizzaRepository.GetAll().FirstOrDefault(x => x.Id == pizzaId && x.CustomerId == customerId);

            if (pizaa == null)
            {
                throw new Exception("Pizza not found");
            }

            var pizzaModel = PizzaMapper.PizzaModelToPizzaDto(pizaa);

            return pizzaModel;
        }
        public List<PizzaDto> GetPizzas(int customerId)
        {
            return _pizzaRepository.GetAll().Where(x => x.CustomerId == customerId).Select(pizza => PizzaMapper.PizzaModelToPizzaDto(pizza)).ToList();
        }

        public void UpdatePizza(PizzaDto pizza)
        {
            var pizzaModel = _pizzaRepository.GetAll().FirstOrDefault(x => x.Id == pizza.Id && x.CustomerId == pizza.CustomerId);

            if (pizzaModel == null)
            {
                throw new Exception("Cannot update pizza");
            }

            var mappedModel = PizzaMapper.PizzaDtoToPizzaModel(pizza);
            _pizzaRepository.Update(mappedModel);
        }
    }
}
