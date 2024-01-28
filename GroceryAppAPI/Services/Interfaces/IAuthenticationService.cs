using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts authentication related functionalities.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Does the login functionality for a specified user.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns>The login response.</returns>
        public LoginResponse Login(LoginRequest loginRequest);
    }
}
