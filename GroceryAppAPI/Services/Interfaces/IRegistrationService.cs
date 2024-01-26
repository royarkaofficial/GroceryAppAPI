using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts registration related functionalities.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// Registers an user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Register(User user);
    }
}
