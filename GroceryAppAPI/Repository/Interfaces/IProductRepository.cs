using GroceryAppAPI.Models.DbModels;
using Microsoft.Data.SqlClient;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for <see cref="Product"/> entity.
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
        /// <param name="query">The conditions.</param>
        /// <param name="product">The product.</param>
        public void Update(string conditions, Product product);

        /// <summary>
        /// Deletes the specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);

        /// <summary>
        /// Updates the status of a specified product as removed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void UpdateStatusAsRemoved(int id);
    }
}
