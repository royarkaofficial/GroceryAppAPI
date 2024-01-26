using GroceryAppAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok(new { Message = "Hello World! This is GroceryAppAPI!"});
        }
    }
}
