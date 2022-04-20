using Microsoft.AspNetCore.Components;
using System.Collections;
using WeightLossApp.Web.Services;

namespace WeightLossApp.Web.Pages
{
    public class FoodItemListBase : ComponentBase
    {
        [Inject]
        public IFoodItemService FoodItemService { get; set; }
        public IEnumerable<FoodItem> FoodItems { get; set; } = default!;
        public List<Day> DaysCollection { get; set; } = new List<Day>();
        public double TotalCalories { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            FoodItems = (await FoodItemService.GetFoodItems()).ToList();
            ArrayList Dates = new ArrayList();
            foreach (var item in FoodItems)
            {
                string itemDate = item.DateTimeEaten.ToString().Split(" ")[0];
                if (Dates.IndexOf(itemDate) == -1)
                {
                    Dates.Add(itemDate);
                    Day newDay = new Day();
                    DaysCollection.Add(newDay);
                }
                DaysCollection[Dates.IndexOf(itemDate)].FoodItems.Add(item);
                DaysCollection[Dates.IndexOf(itemDate)].TotalCalories += (item.CaloriesPerServing * item.Servings);
            }
            DaysCollection.Sort((a, b) => b.FoodItems[0].DateTimeEaten.CompareTo(a.FoodItems[0].DateTimeEaten));
        }

        //private void LoadFoodItems()
        //{
        //    System.Threading.Thread.Sleep(3000);

        //    FoodItem f1 = new FoodItem
        //    {
        //        Id = 1,
        //        Brand = "Kellogs",
        //        Name = "Frosted Flakes",
        //        DateTimeEaten = new DateTime(2022, 4, 4),
        //        CaloriesPerServing = 140,
        //        Servings = 2,
        //        CarbsPerServing = 34,
        //        ProteinPerServing = 2,
        //        CreatedAt = DateTime.Now
        //    };

        //    FoodItem f2 = new FoodItem
        //    {
        //        Id = 2,
        //        Brand = "Monster Energy",
        //        Name = "Ultra Paradise",
        //        DateTimeEaten = new DateTime(2022, 4, 4),
        //        CaloriesPerServing = 10,
        //        Servings = 1,
        //        CarbsPerServing = 3,
        //        ProteinPerServing = 0,
        //        CreatedAt = DateTime.Now
        //    };

        //    FoodItem f3 = new FoodItem
        //    {
        //        Id = 3,
        //        Brand = "JJ's Bakery",
        //        Name = "Lightly Glazed Apple Pie",
        //        DateTimeEaten = new DateTime(2022, 4, 4),
        //        CaloriesPerServing = 390,
        //        Servings = 1,
        //        CarbsPerServing = 59,
        //        ProteinPerServing = 3,
        //        CreatedAt = DateTime.Now
        //    };

        //    FoodItems = new List<FoodItem> { f1, f2, f3 };
        //}
    }
}
