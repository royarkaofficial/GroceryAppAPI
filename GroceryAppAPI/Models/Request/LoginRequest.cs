using GroceryAppAPI.Enumerations;

namespace GroceryAppAPI.Models.Request
{
    /// <summary>
    /// Represents a login request.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
}
