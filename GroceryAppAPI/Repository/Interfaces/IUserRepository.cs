using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for <see cref="User"/> entity.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        public User Get(int id);

        /// <summary>
        /// Gets the specified user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The user.</returns>
        public User Get(string email);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        public void Update(int id, string password);

        /// <summary>
        /// Adds the specified user. 
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(User user);
    }
}
