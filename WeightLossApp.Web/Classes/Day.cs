namespace WeightLossApp.Web.Pages
{
    public class Day
    {
        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
        public double TotalCalories { get; set; } = 0;
        public string Date { get; set; } = default!;
    }
}
