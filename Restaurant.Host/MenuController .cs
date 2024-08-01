using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Interfaces;
using Restaurant.Contracts.DTOs;

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
            var foods = _foodService.GetFoodItems();
            var foodDtos = foods.Select(f => new FoodItemDto { Name = f.Name, Price = f.Price }).ToList();
            return Ok(foodDtos);
        }
    }
}
