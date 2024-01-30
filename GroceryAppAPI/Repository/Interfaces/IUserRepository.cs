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
        /// <param name="conditions">The conditions.</param>
        /// <param name="user">The user.</param>
        public void Update(string conditions, User user);

        /// <summary>
        /// Updates the password of a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="passwordHash">The password hash.</param>
        public void Update(int id, string passwordHash);

        /// <summary>
        /// Adds the specified user. 
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(User user);
    }
}
