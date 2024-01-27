using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var user = _userService.Get(id);
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] string password)
        {
            _userService.Update(id, password);
            return Ok(new {Message = "Password updated successfully."});
        } 
    }
}
