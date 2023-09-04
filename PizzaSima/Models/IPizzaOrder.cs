namespace PizzaSima.Models
{
    public interface IPizzaOrder
    {

        public IEnumerable<PizzaOrder> GetOrders();

        public void AddPizzaOrder(PizzaOrder pizzaOrder);
 
        public void RemovePizzaOrder(int id);


    }
}
