using Microsoft.EntityFrameworkCore;

namespace WeightLossApp.Api.Data
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly WeightLossDbContext dbContext;

        public FoodItemRepository(WeightLossDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<FoodItem>> GetFoodItems()
        {
            return await dbContext.FoodItems.ToListAsync();
        }

        public async Task<FoodItem> GetFoodItem(int id)
        {
            return await dbContext.FoodItems
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<FoodItem> GetFoodItemByName(string name)
        {
            return await dbContext.FoodItems
                .FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<FoodItem> AddFoodItem(FoodItem foodItem)
        {
            var result = await dbContext.FoodItems.AddAsync(foodItem);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FoodItem> UpdateFoodItem(FoodItem foodItem)
        {
            var result = await dbContext.FoodItems
                .FirstOrDefaultAsync(e => e.Id == foodItem.Id);

            if(result != null)
            {
                result.Id = foodItem.Id;
                result.Brand = foodItem.Brand;
                result.Name = foodItem.Name;
                result.DateTimeEaten = foodItem.DateTimeEaten;
                result.Servings = foodItem.Servings;
                result.CaloriesPerServing = foodItem.CaloriesPerServing;
                result.CarbsPerServing = foodItem.CarbsPerServing;
                result.ProteinPerServing = foodItem.ProteinPerServing;
                result.CreatedAt = DateTime.Now;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;


        }

        public async Task<FoodItem> DeleteFoodItem(int id)
        {
            var result = await dbContext.FoodItems
                .FirstOrDefaultAsync(e => e.Id == id);
            if(result != null)
            {
                dbContext.FoodItems.Remove(result);
                await dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<FoodItem>> Search(string searchTerm)
        {
            IQueryable<FoodItem> query = dbContext.FoodItems;

            if(!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(e => e.Name.Contains(searchTerm) || e.Brand.Contains(searchTerm));
                
            }

            return await query.ToListAsync();
            
        }
    }
}
