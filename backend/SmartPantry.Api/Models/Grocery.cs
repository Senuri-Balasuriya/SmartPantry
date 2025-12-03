using System;




namespace SmartPantry.Models
{
    public class Grocery
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }

        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
        public string Unit { get; internal set; }
    }
}
