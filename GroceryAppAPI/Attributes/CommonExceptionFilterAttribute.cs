using GroceryAppAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GroceryAppAPI.Attributes
{
    /// <summary>
    /// A filter that catches all the common exceptions and sets the HTTP response accordingly.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute" />
    public class CommonExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnException(ExceptionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            switch (context.Exception)
            {
                case InvalidRequestException:
                case InvalidRequestDataException:
                case PaymentFailedException:
                case ArgumentNullException:
                case EntityNotFoundException:
                default:
                    context.Result = new BadRequestObjectResult(new { Message = context.Exception.Message });
                    break;
            }
        }
    }
}
