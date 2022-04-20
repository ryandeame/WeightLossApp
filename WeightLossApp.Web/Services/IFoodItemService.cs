namespace WeightLossApp.Web.Services
{
    public interface IFoodItemService
    {
        //Task<IEnumerable<FoodItem>> Search(string searchTerm);
        Task<IEnumerable<FoodItem>> GetFoodItems();
        Task<FoodItem> GetFoodItem(int id);
        ////Task<FoodItem> GetFoodItemByName(string name);
        Task<HttpResponseMessage> CreateFoodItem(FoodItem newFoodItem);
        Task<HttpResponseMessage> UpdateFoodItem(FoodItem updatedFoodItem);
        //Task<FoodItem> DeleteFoodItem(int id);
    }
}
