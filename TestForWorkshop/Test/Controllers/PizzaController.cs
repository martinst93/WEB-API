using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Dto;
using Test.Services.Interface;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("getAllPizzas/{pizzaId}")]
        public ActionResult<List<PizzaDto>> GetAllPizzas(int pizzaId)
        {
            return _pizzaService.GetPizzas(pizzaId);
        }

        [HttpPost("getPizzaDetails")]
        public ActionResult<PizzaDto> GetPizzaDetails(int pizzaId, int customerId)
        {
            try
            {
                return _pizzaService.GetPizzaDetails(pizzaId, customerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddPizza")]
        public ActionResult<string> AddPizza(PizzaDto pizza)
        {
            try
            {
                return _pizzaService.AddPizza(pizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deletePizza")]
        public ActionResult<string> DeletePizza(int pizzaId, int userId)
        {
            try
            {
                return _pizzaService.DeletePizza(pizzaId, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
