namespace SmartPantry.Api.DTOs.Grocery
{
    public class GroceryUpdateDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
