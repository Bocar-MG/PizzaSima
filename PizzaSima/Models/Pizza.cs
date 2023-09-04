namespace PizzaSima.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string Description { get;set; } = string.Empty;

        public string Ingredients { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public double Prix { get; set; }


    }
}
