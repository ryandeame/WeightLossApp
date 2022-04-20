using Microsoft.EntityFrameworkCore;

namespace WeightLossApp.Api.Data
{
    public class WeightLossDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        public WeightLossDbContext(DbContextOptions<WeightLossDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                Id = 1,
                Brand = "Kellogs",
                Name = "Frosted Flakes",
                DateTimeEaten = new DateTime(2022, 4, 4),
                CaloriesPerServing = 140,
                Servings = 2,
                CarbsPerServing = 34,
                ProteinPerServing = 2,
                CreatedAt = DateTime.Now
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                Id = 2,
                Brand = "Monster Energy",
                Name = "Ultra Paradise",
                DateTimeEaten = new DateTime(2022, 4, 4),
                CaloriesPerServing = 10,
                Servings = 1,
                CarbsPerServing = 3,
                ProteinPerServing = 0,
                CreatedAt = DateTime.Now
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                Id = 3,
                Brand = "JJ's Bakery",
                Name = "Lightly Glazed Apple Pie",
                DateTimeEaten = new DateTime(2022, 4, 4),
                CaloriesPerServing = 390,
                Servings = 1,
                CarbsPerServing = 59,
                ProteinPerServing = 3,
                CreatedAt = DateTime.Now
            });
        }
    }
}
