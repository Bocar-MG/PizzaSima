using System.ComponentModel.DataAnnotations;

namespace PizzaSima.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Veuillez renseigner votre Nom")]
        public string NomClient { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veuillez renseigner votre Adresse")]

        public string Adresse { get; set; } = string.Empty;


        [Required(ErrorMessage = "Veuillez saisir votre numero de telephone")]
        [Phone]
        public string Telephone { get; set; } = string.Empty;

        public int NumeroPizza { get; set; }
        public string? NomPizza { get; set; }

    }
}
