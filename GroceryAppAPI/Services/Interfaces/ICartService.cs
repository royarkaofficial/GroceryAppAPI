using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts cart related functionalities.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the specified cart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The cart.</returns>
        public Models.Response.Cart Get(int userId);

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
        /// <param name="userId">The user identifier.</param>
        public void Delete(int id, int userId);

        /// <summary>
        /// Updates the specified cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cart">The cart.</param>
        public void Update(int id, Cart cart);
    }
}
