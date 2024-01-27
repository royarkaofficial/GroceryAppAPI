using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services.Interfaces;
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

        [HttpGet]
        public IActionResult Get([FromRoute] int userId)
        {
            var orders = _orderService.GetAll(userId);
            return Ok(orders);
        }

        [HttpPost("payments")]
        public IActionResult Payment([FromRoute] int id,[FromRoute] int userId, [FromBody] PaymentRequest paymentRequest)
        {
            paymentRequest.Order.UserId = userId;
            var (orderId, paymentId) = _orderService.Pay(id, paymentRequest);
            return Ok(new { OrderId = orderId, PaymentId = paymentId });
        }
    }
}
