using GroceryAppAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    /// <summary>
    /// Base class for all controllers.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [CommonExceptionFilter]
    public class BaseController : ControllerBase
    {
    }
}
