using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Data;

namespace Test.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            CacheDb.UserId++;
            entity.Id = CacheDb.UserId;

            CacheDb.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            Customer customer = CacheDb.Customers.FirstOrDefault(x => x.Id == entity.Id);

            if (customer is not null)
            {
                CacheDb.Customers.Remove(entity);
            }
        }

        public List<Customer> GetAll()
        {
            return CacheDb.Customers;
        }

        public void Update(Customer entity)
        {
            Customer customer = CacheDb.Customers.FirstOrDefault(x => x.Id == entity.Id);

            if (customer is not null)
            {
                var index = CacheDb.Customers.IndexOf(customer);
                CacheDb.Customers[index] = entity;
            }
        }
    }
}
