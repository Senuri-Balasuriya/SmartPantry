using AutoMapper;
using SmartPantry.Api.DTOs.Grocery;
using SmartPantry.Api.Models;


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
