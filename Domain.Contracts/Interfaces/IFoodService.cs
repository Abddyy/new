namespace Restaurant.Contracts
{
    public interface IFoodService
    {
        List<FoodItemDto> GetFoodItems();
        void AddFoodItem(FoodItemDto foodItem);
        bool UpdateFoodItem(string name, FoodItemDto updatedFoodItem);
        bool DeleteFoodItem(string name);

    }
}
