using GroceryAppAPI.Exceptions;
using System.Security.Claims;

namespace GroceryAppAPI.Helpers
{
    /// <summary>
    /// A helper class for claiming identity.
    /// </summary>
    public static class IdentityClaimHelper
    {
        /// <summary>
        /// Claims the identity of the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="contextAccessor">The context accessor.</param>
        /// <returns></returns>
        /// <exception cref="InvalidRequestException">User is denied to access the specified resouce.</exception>
        public static bool ClaimUser(string email, IHttpContextAccessor contextAccessor)
        {
            var identity = contextAccessor.HttpContext.User.Claims;
            var identityClaim = identity.FirstOrDefault(id => id.Type == ClaimTypes.Email && id.Value == email);

            if (identityClaim is null)
            {
                throw new InvalidRequestException("User is denied to access the specified resouce.");
            }

            return true;
        }
    }
}
