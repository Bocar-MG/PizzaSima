using PizzaSima.Data;

namespace PizzaSima.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaDataContext pizzaDataContext;
        private readonly IWebHostEnvironment env;
        public PizzaRepository(PizzaDataContext pizzaDataContext, IWebHostEnvironment webHostEnvironment)
        {
            this.pizzaDataContext = pizzaDataContext;
            this.env = webHostEnvironment;
        }

        public void AddPizza(Pizza pizza, IFormFile file)
        {
            if(file != null)
            {
                var NomFichier = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var CheminStockageImage = Path.Combine(env.WebRootPath, "PizzaImages", NomFichier);

                using(var stream = new FileStream(CheminStockageImage,FileMode.Create))
                {
                    file.CopyTo(stream);

                }
                pizza.ImageUrl = NomFichier;

            }
            pizzaDataContext.PizzaSimas.Add(pizza);
            pizzaDataContext.SaveChanges();
        }

        public void DeletePizza(int id)
        {
            var pizza = pizzaDataContext.PizzaSimas.Find(id);
            if(pizza != null)
            {
                pizzaDataContext.Remove(pizza);
                pizzaDataContext.SaveChanges();
            }
        }

        public IEnumerable<Pizza> GetAll()
        {
           return pizzaDataContext.PizzaSimas.ToList();
        }

       public Pizza GetBy(int id)
        {
            return pizzaDataContext.PizzaSimas.Find(id);
            
        }

       public void UpdatePizza(Pizza pizza, IFormFile file)
        {
            if (file != null)
            {
                var NomFichier = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var CheminStockageImage = Path.Combine(env.WebRootPath, "PizzaImages", NomFichier);

                using (var stream = new FileStream(CheminStockageImage, FileMode.Create))
                {
                    file.CopyTo(stream);
                   

                }
                pizza.ImageUrl = NomFichier;
                pizzaDataContext.PizzaSimas.Update(pizza);
                pizzaDataContext.SaveChanges();

            }
            else
            {
                pizzaDataContext.PizzaSimas.Update(pizza);
                pizzaDataContext.SaveChanges();
            }
           
        }
    }
}
