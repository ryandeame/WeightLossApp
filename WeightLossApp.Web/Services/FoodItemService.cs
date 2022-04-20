using System.Net.Http.Json;

namespace WeightLossApp.Web.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly HttpClient httpClient;
        public FoodItemService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FoodItem>> GetFoodItems()
        {
            return await httpClient.GetFromJsonAsync<FoodItem[]>("api/fooditems");
        }

        public async Task<FoodItem> GetFoodItem(int id)
        {
            return await httpClient.GetFromJsonAsync<FoodItem>($"api/fooditems/{id}");
        }

        public async Task<HttpResponseMessage> UpdateFoodItem(FoodItem updatedFoodItem)
        {
            return await httpClient.PutAsJsonAsync("api/fooditems", updatedFoodItem);
        }

        public async Task<HttpResponseMessage> CreateFoodItem(FoodItem newFoodItem)
        {
            return await httpClient.PostAsJsonAsync("api/fooditems", newFoodItem);
        }
    }
}
