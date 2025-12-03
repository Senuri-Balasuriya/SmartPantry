using System.Collections.Generic;

namespace SmartPantry.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

        // Store only hashed password
        public string PasswordHash { get; set; }

        // Relationships
        public ICollection<Grocery> Groceries { get; set; }
        public ICollection<ConsumptionHistory> ConsumptionHistories { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public EcoPoints EcoPoints { get; set; }
        public ICollection<SmartShoppingSuggestion> ShoppingSuggestions { get; set; }
    }
}
