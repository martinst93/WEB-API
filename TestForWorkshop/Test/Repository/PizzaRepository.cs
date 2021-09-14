using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;

namespace Test.Repository
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void Add(Pizza entity)
        {
            CacheDb.PizzaId++;
            entity.Id = CacheDb.PizzaId;

            CacheDb.Pizzas.Add(entity);
        }

        public void Delete(Pizza entity)
        {
            Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);

            if (pizza is not null)
            {
                CacheDb.Pizzas.Remove(entity);
            }
        }

        public List<Pizza> GetAll()
        {
            return CacheDb.Pizzas;
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);

            if(pizza is not null)
            {
                var index = CacheDb.Pizzas.IndexOf(pizza);
                CacheDb.Pizzas[index] = entity;
            }
        }
    }
}
