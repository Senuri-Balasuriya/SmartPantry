using Microsoft.EntityFrameworkCore;
using SmartPantry.Api.Models;

namespace SmartPantry.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<ConsumptionHistory> ConsumptionHistories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EcoPoints> EcoPoints { get; set; }
        public DbSet<SmartShoppingSuggestion> SmartShoppingSuggestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure ConsumptionHistory relationships to prevent multiple cascade paths
            modelBuilder.Entity<ConsumptionHistory>()
                .HasOne(ch => ch.User)
                .WithMany(u => u.ConsumptionHistories)
                .HasForeignKey(ch => ch.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Change from Cascade to NoAction

            modelBuilder.Entity<ConsumptionHistory>()
                .HasOne(ch => ch.Grocery)
                .WithMany()
                .HasForeignKey(ch => ch.GroceryId)
                .OnDelete(DeleteBehavior.Cascade); // Keep Cascade for Grocery
        }
    }
}
