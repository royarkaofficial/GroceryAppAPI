using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts product related functionalities.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll();

        /// <summary>
        /// Adds a specific product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(Product product);

        /// <summary>
        /// Updates a specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        public void Update(int id, Product product);

        /// <summary>
        /// Deletes a specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
