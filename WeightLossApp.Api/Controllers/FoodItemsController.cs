using Microsoft.AspNetCore.Mvc;
using WeightLossApp.Api.Data;
using System.Linq;

namespace WeightLossApp.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]

    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemRepository foodItemRepository;

        public FoodItemsController(IFoodItemRepository foodItemRepository)
        {
            this.foodItemRepository = foodItemRepository;
        }   

        [HttpGet]
        public async Task<ActionResult> GetFoodItems()
        {
            try
            {
                return Ok(await foodItemRepository.GetFoodItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(int id)
        {
            try
            {
                var result = await foodItemRepository.GetFoodItem(id);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Could not retrieve information. Please try later.");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<FoodItem>> Search(string searchTerm)
        {
            try
            {
                
                var result = await foodItemRepository.Search(searchTerm);

                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Could not retrieve information. Please try later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FoodItem>> CreateFoodItem(FoodItem foodItem)
        {
            try
            {
                if(foodItem == null)
                {
                    return BadRequest();
                }

                var item = await foodItemRepository.GetFoodItem(foodItem.Id);

                if(item != null)
                {
                    ModelState.AddModelError("record", "Food item already exists.");
                    return BadRequest(ModelState);
                }

                foodItem.CreatedAt = DateTime.Now;

                var createdFoodItem = await foodItemRepository.AddFoodItem(foodItem);

                if (createdFoodItem != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);

                //return CreatedAtAction(nameof(GetFoodItem), new { id = createdFoodItem.Id }, createdFoodItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Could not add new food item. Please try later.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<FoodItem>> UpdateFoodItem(FoodItem foodItem)
        {
            try
            {
                var foodItemToUpdate = await foodItemRepository.GetFoodItem(foodItem.Id);

                if (foodItemToUpdate == null)
                {
                    return NotFound($"Food item with ID {foodItem.Id} not found.");
                }

                var result = await foodItemRepository.UpdateFoodItem(foodItem);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                } 

                return StatusCode(StatusCodes.Status404NotFound);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Could not update information. Please try later.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FoodItem>> DeleteFoodItem(int id)
        {
            try
            {
                var foodItemToDelete = await foodItemRepository.GetFoodItem(id);

                if(foodItemToDelete == null)
                {
                    return NotFound("Could not find item to delete.");
                }

                return await foodItemRepository.DeleteFoodItem(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Could not delete food item.");
            }
        }
    }
}
