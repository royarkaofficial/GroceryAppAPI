using GroceryAppAPI.Models;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for product entity.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll();

        /// <summary>
        /// Gets the specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        public Product Get(int id);

        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(Product product);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        public void Update(int id, Product product);

        /// <summary>
        /// Deletes the specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
