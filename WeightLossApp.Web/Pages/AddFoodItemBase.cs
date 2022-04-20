using Microsoft.AspNetCore.Components;
using WeightLossApp.Web.Services;

namespace WeightLossApp.Web.Pages
{
    public class AddFoodItemBase : ComponentBase
    {
        public FoodItem FoodItem { get; set; }

        public string UpdateErrorMessage { get; set; } = "Could not add food item. Please try again later.";

        public string Visibility { get; set; } = "visibility: hidden;";

        [Inject]
        public IFoodItemService FoodItemService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public string Id { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            FoodItem = new FoodItem
            {
                Brand = "Brand",
                Name = "Name",
                DateTimeEaten = DateTime.Now,
                Servings = 1,
                CaloriesPerServing = 0,
                CarbsPerServing = 0,
                ProteinPerServing = 0,
            };
        }

        protected async Task HandleValidSubmit()
        {
            var result = await FoodItemService.CreateFoodItem(FoodItem);

            if (result.IsSuccessStatusCode == true)
            {
                NavigationManager.NavigateTo("/");
            } 
            else
            {
                Visibility = "visibility: visible;";
            }
        }
    }
}
