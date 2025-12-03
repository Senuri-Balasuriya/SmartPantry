using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPantry.Api.DTOs.Grocery;
using SmartPantry.Services.Interfaces;

namespace SmartPantry.Controllers
{
    [ApiController]
    [Route("api/grocery")]
    [Authorize]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryService _service;

        public GroceryController(IGroceryService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            return int.Parse(User.Claims.First(c => c.Type == "userId").Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddGrocery(GroceryCreateDto dto)
        {
            var userId = GetUserId();
            var result = await _service.AddGrocery(dto, userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrocery(int id, GroceryUpdateDto dto)
        {
            var userId = GetUserId();
            var result = await _service.UpdateGrocery(id, dto, userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrocery(int id)
        {
            var userId = GetUserId();
            await _service.DeleteGrocery(id, userId);
            return Ok(new { message = "Deleted successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetGroceries()
        {
            var userId = GetUserId();
            var result = await _service.GetGroceries(userId);
            return Ok(result);
        }
    }
}
