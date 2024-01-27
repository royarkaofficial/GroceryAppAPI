using GroceryAppAPI.Models;

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
        public void Login(LoginRequest loginRequest);
    }
}
