using AutoMapper;
using Restaurant.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<FoodItemDto, FoodItem>()

            .ForMember(dest => dest.Id, opt => opt.Ignore()); 
        CreateMap<DrinkItem, DrinkItemDto>();
        CreateMap<DrinkItemDto, DrinkItem>().ForMember(dest=>dest.Id, opt => opt.Ignore());
    }
}
