﻿using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cart cart)
        {
            var id = _cartService.Add(cart);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int userId)
        {
            var cart = _cartService.Get(userId);

            if (cart is null)
            {
                return Ok(new { Message = "User does not have any cart." });
            }

            return Ok(cart);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Cart cart)
        {
            _cartService.Update(id, cart);
            return Ok(new { Message = "Cart updated successfully" });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _cartService.Delete(id);
            return Ok(new { Message = "Cart deleted successfully" });
        }
    }
}
