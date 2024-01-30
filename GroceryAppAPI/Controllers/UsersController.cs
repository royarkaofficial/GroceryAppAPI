using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var userResponse = _userService.Get(id);
            return Ok(new { data = userResponse });
        }

        [Authorize]
        [HttpPatch("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] string properties)
        {
            _userService.Update(id, properties);
            return Ok(new {Message = "User details updated successfully."});
        }
    }
}
