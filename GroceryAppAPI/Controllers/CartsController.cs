using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("users/{userId:int}/[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromRoute] int userId, [FromBody] CartRequest cartRequest)
        {
            var id = _cartService.Add(userId, cartRequest);
            return Ok(new { data = new { Id = id } });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromRoute] int userId)
        {
            var cart = _cartService.Get(userId);
            if (cart is null) { return Ok(new { Message = "User does not have any cart." }); }
            return Ok(cart);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromRoute] int userId, [FromBody] CartRequest cartRequest)
        {
            _cartService.Update(id, userId, cartRequest);
            return Ok(new { Message = "Cart updated successfully." });
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromRoute] int userId)
        {
            _cartService.Delete(id, userId);
            return Ok(new { Message = "Cart deleted successfully." });
        }
    }
}
