using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaSima.Models;

namespace PizzaSima.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository pizzaRepository;
        private readonly IPizzaOrder pizzaOrderRepository;
        static Pizza? selectedItem;
        Boolean success = false;

        public HomeController(IPizzaRepository pizzaRepository, IPizzaOrder pizzaOrderRepository)
        {
            this.pizzaRepository = pizzaRepository;
            this.pizzaOrderRepository = pizzaOrderRepository;

           

        }
        
        public IActionResult Index()
        {

            return View(pizzaRepository.GetAll());
        }

        public IActionResult Detail(int id)
        {
            var pizza = pizzaRepository.GetBy(id);
            selectedItem = pizza;
            return View(pizza);
        
        
        }
        [Authorize]
        public IActionResult Commande()  
        {
          ViewBag.item = selectedItem;
          return View();
        }

        [HttpPost]
        public IActionResult Commande(PizzaOrder pizzaOrder)
        {
            
            if (ModelState.IsValid)
            {
                pizzaOrder.NomPizza = selectedItem.Nom;
                pizzaOrder.NumeroPizza = selectedItem.Id;
                pizzaOrderRepository.AddPizzaOrder(pizzaOrder);
                return RedirectToAction("SuccessOrder");
            }
            ViewBag.Item = selectedItem;
            return View(pizzaOrder);


        }
        public IActionResult SuccessOrder()
        {
            ViewBag.SuccessMessage = "Merci pour la commande Vous serez bientot livrez";
            return View();
        }
       


        

       
    }
}
