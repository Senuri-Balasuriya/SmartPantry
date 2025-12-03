namespace SmartPantry.Api.DTOs.Grocery
{
    public class GroceryCreateDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
