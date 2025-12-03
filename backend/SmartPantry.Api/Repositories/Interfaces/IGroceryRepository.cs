using SmartPantry.Models;

namespace SmartPantry.Repositories.Interfaces
{
    public interface IGroceryRepository
    {
        Task Add(Grocery item);
        Task Update(Grocery item);
        Task Delete(Grocery item);
        Task<Grocery> GetById(int id);
        Task<List<Grocery>> GetByUser(int userId);
    }
}
