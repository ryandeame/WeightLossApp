using Microsoft.AspNetCore.Components;
using WeightLossApp.Web.Services;

namespace WeightLossApp.Web.Pages
{
    public class EditFoodItemBase : ComponentBase
    {
        public FoodItem FoodItem { get; set; } = new FoodItem();

        public string UpdateErrorMessage { get; set; } = "Could not update food item. Please try again later.";

        public string Visibility { get; set; } = "visibility: hidden;";

        [Inject]
        public IFoodItemService FoodItemService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public string Id { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            FoodItem = await FoodItemService.GetFoodItem(int.Parse(Id));
        }

        protected async Task HandleValidSubmit()
        {
            var result = await FoodItemService.UpdateFoodItem(FoodItem);

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
