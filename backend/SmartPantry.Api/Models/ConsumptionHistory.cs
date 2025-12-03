using System;

namespace SmartPantry.Models
{
    public class ConsumptionHistory
    {
        public int Id { get; set; }

        public int GroceryId { get; set; }
        public Grocery Grocery { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime ConsumedDate { get; set; }
        public int QuantityUsed { get; set; }
    }
}
