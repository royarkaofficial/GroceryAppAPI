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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromRoute] int userId)
        {
            var orders = _orderService.GetAll(userId);
            return Ok(orders);
        }

        [Authorize]
        [HttpPost("place")]
        public IActionResult Payment([FromRoute] int userId, [FromBody] OrderPlacementRequest placementRequest)
        {
            var placementResponse = _orderService.Place(userId, placementRequest);
            return Ok(new { data = placementResponse });
        }
    }
}
