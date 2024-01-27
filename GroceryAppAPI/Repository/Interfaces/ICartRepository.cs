using GroceryAppAPI.Models;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstract database utilities for <see cref="Cart"/> entity.
    /// </summary>
    public interface ICartRepository
    {
        /// <summary>
        /// Gets the specified cart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The cart.</returns>
        public Cart GetByUser(int userId);

        /// <summary>
        /// Gets the specified cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The cart.</returns>
        public Cart Get(int id);

        /// <summary>
        /// Adds the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(Cart cart);

        /// <summary>
        /// Deletes the specified cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
