using Microsoft.AspNetCore.Components;
using WeightLossApp.Web.Services;

namespace WeightLossApp.Web.Pages
{
    public class FoodItemDetailsBase : ComponentBase
    {
        public FoodItem FoodItem { get; set; } = new FoodItem();
        public double TotalCalories = 0;

        [Inject]
        public IFoodItemService FoodItemService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            FoodItem = await FoodItemService.GetFoodItem(int.Parse(Id));
            TotalCalories = FoodItem.Servings * FoodItem.CaloriesPerServing;
        }
    }
}
