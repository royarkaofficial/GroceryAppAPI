using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for cart product mapping.
    /// </summary>
    public interface ICartProductRepository
    {
        /// <summary>
        /// Gets all the products for a specified cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>All products for a cart.</returns>
        public IEnumerable<CartProduct> GetAll(int cartId);

        /// <summary>
        /// Adds the specified cart product mapping.
        /// </summary>
        /// <param name="cartProduct">The cart product.</param>
        public void Add(CartProduct cartProduct);

        /// <summary>
        /// Deletes the specified cart product mapping.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productId">The product identifier.</param>
        public void Delete(int id, int productId);

        /// <summary>
        /// Deletes all product mappings for a specified cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
