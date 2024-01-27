using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstract business logic for user entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A specified user.</returns>
        public User Get(int id);

        /// <summary>
        /// Updates a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        public void Update(int id, string password);
    }
}
