using GroceryAppAPI.Models.Response;

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
        /// <returns>The user response.</returns>
        public UserResponse Get(int id);

        /// <summary>
        /// Updates a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        public void Update(int id, string password);
    }
}
