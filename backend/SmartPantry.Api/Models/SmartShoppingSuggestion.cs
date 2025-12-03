using System;

namespace SmartPantry.Models
{
    public class SmartShoppingSuggestion
    {
        public int Id { get; set; }

        public string SuggestedItem { get; set; }
        public int RecommendedQuantity { get; set; }
        public DateTime SuggestedDate { get; set; }

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
