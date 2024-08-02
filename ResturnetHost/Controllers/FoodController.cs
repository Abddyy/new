using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts;
using System.Collections.Generic;

namespace Restaurant.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IDrinkService _drinkService;

        public MenuController(IFoodService foodService, IDrinkService drinkService)
        {
            _foodService = foodService;
            _drinkService = drinkService;
        }

        [HttpGet("food")]
        public ActionResult<IEnumerable<FoodItemDto>> GetFood()
        {
            var foodDtos = _foodService.GetFoodItems();
            return Ok(foodDtos);
        }

        [HttpGet("drinks")]

        public ActionResult<IEnumerable<DrinkItemDto>> GetDrinks()
        {
            var drinkDtos = _drinkService.GetDrinkItemDtos();
            return Ok(drinkDtos);
        }

        [HttpPost("food")]
        public IActionResult AddFood(FoodItemDto foodItem)
        {
            _foodService.AddFoodItem(foodItem);
            return CreatedAtAction(nameof(GetFood), new { name = foodItem.Name }, foodItem);
        }
        [HttpPost("drinks")]

        public IActionResult AddDrinks(DrinkItemDto drinkItemDto)
        {
            _drinkService.AddDrinkItem(drinkItemDto);
            return CreatedAtAction(nameof(GetDrinks), new { name = drinkItemDto.Name }, drinkItemDto);
        }


        [HttpDelete("food/{name}")]
        public IActionResult DeleteFood(string name)
        {
            var result = _foodService.DeleteFoodItem(name);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"food item with name '{name}'is not found." });
        }


        [HttpDelete("drinks/{name}")]

        public IActionResult Deletedrink(string name)
        {
            var result = _drinkService.DeleteDrinkItem(name);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"Drink item with name '{name}'is not found." });
        }

        [HttpPut("foods/{name}")]
        public IActionResult UpdateFood(string name, FoodItemDto updatedFoodItem)
        {
            var result = _foodService.UpdateFoodItem(name, updatedFoodItem);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"food item with name '{name}'is not found." });
        }


        [HttpPut("drinks/{name}")]
        public IActionResult UpdateDrinks(string name, DrinkItemDto drinkItemDto)
        {
            var result = _drinkService.UpdateDrinkItem(name, drinkItemDto);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"drink item with name '{name}'is not found." });
        }
    }
}
