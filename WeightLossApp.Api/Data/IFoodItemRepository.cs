namespace WeightLossApp.Api.Data
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> Search(string searchTerm);
        Task<IEnumerable<FoodItem>> GetFoodItems();
        Task<FoodItem> GetFoodItem(int id);
        //Task<FoodItem> GetFoodItemByName(string name);
        Task<FoodItem> AddFoodItem(FoodItem foodItem);
        Task<FoodItem> UpdateFoodItem(FoodItem foodItem);
        Task<FoodItem> DeleteFoodItem(int id);

    }
}
