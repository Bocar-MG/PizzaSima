using PizzaSima.Data;

namespace PizzaSima.Models
{
    public class PizzaOrderRepository : IPizzaOrder
    {
        private readonly PizzaDataContext pizzaDataContext;


       public  PizzaOrderRepository(PizzaDataContext pizzaDataContext)
        {
            this.pizzaDataContext = pizzaDataContext;
        }
        public void AddPizzaOrder(PizzaOrder pizzaOrder)
        {
            pizzaDataContext.PizzaOrders.Add(pizzaOrder);
            pizzaDataContext.SaveChanges();


        }

        public IEnumerable<PizzaOrder> GetOrders()
        {
           return pizzaDataContext.PizzaOrders.ToList();
        }

        public void RemovePizzaOrder(int id)
        {
            var order = pizzaDataContext.PizzaOrders.Find(id);
            pizzaDataContext.PizzaOrders.Remove(order);
            pizzaDataContext.SaveChanges();
        }
    }
}
