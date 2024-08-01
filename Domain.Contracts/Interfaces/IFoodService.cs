namespace Restaurant.Contracts
{
    public interface IFoodService
    {
        List<FoodItemDto> GetFoodItems();
        void AddFoodItem(FoodItemDto foodItem);
        bool DeleteFoodItem(string name);
        bool UpdateFoodItem(string name, FoodItemDto updatedFoodItem);
    }
}
