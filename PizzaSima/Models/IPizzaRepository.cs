namespace PizzaSima.Models
{
    public interface IPizzaRepository
    {
        public IEnumerable<Pizza> GetAll();

        public  Pizza GetBy(int id);

        public void AddPizza(Pizza pizza, IFormFile file);
        public void UpdatePizza(Pizza pizza, IFormFile file);

        public void DeletePizza(int id);
    }
}
