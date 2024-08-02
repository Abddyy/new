 namespace Restaurant.Contracts
{
    public interface IDrinkService
    {
        List<DrinkItemDto> GetDrinkItemDtos();
        void AddDrinkItem(DrinkItemDto drinkItemDto);
        bool UpdateDrinkItem(string name,DrinkItemDto drinkItemDto);
        bool DeleteDrinkItem(string name);
    }
}
