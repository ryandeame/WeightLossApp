using System.ComponentModel.DataAnnotations;
using WeightLossApp.Models.CustomValidators;

namespace WeightLossApp
{
    public class FoodItem
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter the brand of the item.")]
        [MinLength(2)]
        public string Brand { get; set; } = default!;
        [Required(ErrorMessage = "Please enter the name of the item.")]
        [MinLength(2)]
        public string Name { get; set; } = default!;
        [Required]
        public DateTime DateTimeEaten { get; set; }
        [Required]
        [ServingsValidator]
        public double Servings { get; set; }
        [Required]
        public int CaloriesPerServing { get; set; }
        [Required]
        public int CarbsPerServing { get; set; }
        [Required]
        public int ProteinPerServing { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}