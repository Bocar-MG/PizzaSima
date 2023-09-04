using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSima.Models;

namespace PizzaSima.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IPizzaRepository pizzaRepository;
        private readonly IPizzaOrder pizzaOrder;

        public AdminController(IPizzaRepository pizzaRepository,IPizzaOrder pizzaOrder)
        {
            this.pizzaRepository = pizzaRepository;
            this.pizzaOrder = pizzaOrder;

        }
        public IActionResult Index()
        {
           return View(pizzaRepository.GetAll());
        }
        
        public IActionResult CreatePizza()
        {

            return View();

        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                pizzaRepository.AddPizza(pizza, file);
                return RedirectToAction("Index");

            }
            return View(pizza);


        }
        public IActionResult UpdatePizza(int id)
        {
            var pizza = pizzaRepository.GetBy(id);
            return View(pizza);

        }

        [HttpPost]
        public IActionResult UpdatePizza(Pizza pizza, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                pizzaRepository.UpdatePizza(pizza, file);
                return RedirectToAction("Index");

            }
            return View(pizza);


        }

        public IActionResult DeletePizza(int id)
        {
           
             pizzaRepository.DeletePizza(id);
            return RedirectToAction("Index");
        }

        public IActionResult ClientOrder() 
        { 
        
            return View(pizzaOrder.GetOrders());
        
        }
        public IActionResult DeletePizzaOrder(int id)
        {

            pizzaOrder.RemovePizzaOrder(id);
            return RedirectToAction("ClientOrder");
        }
    }
}
