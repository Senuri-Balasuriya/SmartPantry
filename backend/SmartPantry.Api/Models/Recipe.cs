using System.Collections.Generic;

namespace SmartPantry.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Instructions { get; set; }

        // e.g., Breakfast, Lunch, Dinner
        public string MealType { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
