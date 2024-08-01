using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FoodItem, FoodItemDto>();
    }
}