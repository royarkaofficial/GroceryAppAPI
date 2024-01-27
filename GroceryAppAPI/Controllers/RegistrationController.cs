using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public IActionResult Registration([FromBody] User user)
        {
            _registrationService.Register(user);
            return Ok(new { Message = "User registered successfully." });
        }
    }
}
