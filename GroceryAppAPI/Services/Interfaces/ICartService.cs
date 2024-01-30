using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

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
        public CartResponse Get(int userId);

        /// <summary>
        /// Adds the specified cart.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cartRequest">The cart request.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(int userId, CartRequest cartRequest);

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
        /// <param name="cartRequest">The cart request.</param>
        /// <param name="userId">The user identifier.</param>
        public void Update(int id, int userId, CartRequest cartRequest);
    }
}
