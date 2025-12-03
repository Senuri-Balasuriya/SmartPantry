using Microsoft.EntityFrameworkCore;
using SmartPantry.Api.Repositories.Interfaces;
using SmartPantry.API.Data;
using SmartPantry.Models;
using SmartPantry.Repositories.Interfaces;

namespace SmartPantry.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly AppDbContext _context;

        public GroceryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Grocery item)
        {
            await _context.Groceries.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Grocery item)
        {
            _context.Groceries.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Grocery item)
        {
            _context.Groceries.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Grocery> GetById(int id)
        {
            return await _context.Groceries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Grocery>> GetByUser(int userId)
        {
            return await _context.Groceries
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
