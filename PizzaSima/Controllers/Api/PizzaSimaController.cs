using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaSima.Models;

namespace PizzaSima.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaSimaController : ControllerBase
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaSimaController(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public IActionResult GetAllPizza() 
        {
            var pizzas = pizzaRepository.GetAll();
            if(pizzas == null)
            {
                return NotFound();
            }
            return Ok(pizzas);
        
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pizza = pizzaRepository.GetBy(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);

        }

    }
}
