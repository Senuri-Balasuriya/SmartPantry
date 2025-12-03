namespace SmartPantry.Api.DTOs.Grocery
{
    public class GroceryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ExpiryStatus { get; set; }
    }
}
