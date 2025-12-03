using AutoMapper;
using SmartPantry.Api.DTOs.Grocery;
using SmartPantry.Models;


namespace SmartPantry.Profiles
{
    public class GroceryProfile : Profile
    {
        public GroceryProfile()
        {
            CreateMap<Grocery, GroceryResponseDto>();
        }
    }
}
