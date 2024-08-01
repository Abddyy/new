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

        public MenuController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("foods")]
        public ActionResult<IEnumerable<FoodItemDto>> GetFoods()
        {
            var foodDtos = _foodService.GetFoodItems();
            return Ok(foodDtos);
        }

        [HttpPost("foods")]
        public IActionResult AddFood(FoodItemDto foodItem)
        {
            _foodService.AddFoodItem(foodItem);
            return CreatedAtAction(nameof(GetFoods), new { name = foodItem.Name }, foodItem);
        }

        [HttpDelete("foods/{name}")]
        public IActionResult DeleteFood(string name)
        {
            var result = _foodService.DeleteFoodItem(name);
            if (result)
            {
                return NoContent();
            }
            return NotFound(new { Message = $"food item with name '{name}'is not found." });
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
    }
}
