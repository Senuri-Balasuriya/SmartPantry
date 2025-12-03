using SmartPantry.DTOs.Grocery;

namespace SmartPantry.Services.Interfaces
{
    public interface IGroceryService
    {
        Task<GroceryResponseDto> AddGrocery(GroceryCreateDto dto, int userId);
        Task<GroceryResponseDto> UpdateGrocery(int id, GroceryUpdateDto dto, int userId);
        Task<bool> DeleteGrocery(int id, int userId);
        Task<List<GroceryResponseDto>> GetGroceries(int userId);
    }
}
