using AutoMapper;
using Restaurant.Contracts;
using Restaurant.Domain;

namespace Restaurant.Application
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private List<FoodItem> _foodItems = new List<FoodItem>
        {
            new FoodItem("burger", 30m),
            new FoodItem("pizza", 50m),
            new FoodItem("falafel", 4.5m)
        };

        public FoodService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<FoodItemDto> GetFoodItems()
        {
            return _mapper.Map<List<FoodItemDto>>(_foodItems);
        }

        public void AddFoodItem(FoodItemDto foodItem)
        {
             _foodItems.Add(_mapper.Map<FoodItem>(foodItem));
        }

        public bool DeleteFoodItem(string name)
        {
            var item = _foodItems.FirstOrDefault(f => f.Name == name && f.IsDeleted != true);
            if (item is null)
            {
                return false;
            }

            item.MarkAsDeleted();
            return true;
        }

        public bool UpdateFoodItem(string name, FoodItemDto updatedFoodItem)
        {
            var item = _foodItems.FirstOrDefault(f => f.Name == name && f.IsDeleted != true);
            if (item is null)
            {
                return false;
            }

            _mapper.Map(updatedFoodItem, item);
            return true;
        }
    }
}