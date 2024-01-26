using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstract business logic for user entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a specific user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A specific user.</returns>
        public User Get(int id);

        /// <summary>
        /// Updates a specific user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        public void Update(int id, string password);
    }
}
