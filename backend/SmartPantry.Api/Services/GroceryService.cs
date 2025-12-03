using AutoMapper;
using SmartPantry.Api.DTOs.Grocery;
using SmartPantry.Models;
using SmartPantry.Repositories.Interfaces;
using SmartPantry.Services.Interfaces;

namespace SmartPantry.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _repo;
        private readonly IMapper _mapper;

        public GroceryService(IGroceryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GroceryResponseDto> AddGrocery(GroceryCreateDto dto, int userId)
        {
            var grocery = new Grocery
            {
                Name = dto.Name,
                Category = dto.Category,
                Quantity = (int)dto.Quantity,
                Unit = dto.Unit,
                ExpiryDate = dto.ExpiryDate,
                UserId = userId
            };

            await _repo.Add(grocery);

            return ConvertToResponse(grocery);
        }

        public async Task<GroceryResponseDto> UpdateGrocery(int id, GroceryUpdateDto dto, int userId)
        {
            var existing = await _repo.GetById(id);
            if (existing == null || existing.UserId != userId)
                throw new Exception("Item not found");

            existing.Name = dto.Name;
            existing.Quantity = (int)dto.Quantity;
            existing.Unit = dto.Unit;
            existing.ExpiryDate = dto.ExpiryDate;

            await _repo.Update(existing);

            return ConvertToResponse(existing);
        }

        public async Task<bool> DeleteGrocery(int id, int userId)
        {
            var existing = await _repo.GetById(id);
            if (existing == null || existing.UserId != userId)
                throw new Exception("Item not found");

            await _repo.Delete(existing);
            return true;
        }

        public async Task<List<GroceryResponseDto>> GetGroceries(int userId)
        {
            var list = await _repo.GetByUser(userId);
            return list.Select(x => ConvertToResponse(x)).ToList();
        }

        private GroceryResponseDto ConvertToResponse(Grocery grocery)
        {
            var dto = _mapper.Map<GroceryResponseDto>(grocery);

            var daysLeft = (grocery.ExpiryDate - DateTime.Now).TotalDays;

            dto.ExpiryStatus =
                daysLeft <= 0 ? "Expired"
                : daysLeft <= 3 ? "Expiring Soon"
                : "Fresh";

            return dto;
        }
    }
}
