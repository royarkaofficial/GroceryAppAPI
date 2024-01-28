using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

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
        public IEnumerable<ProductResponse> GetAll();

        /// <summary>
        /// Adds a specified product.
        /// </summary>
        /// <param name="productRequest">The product request.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(ProductRequest productRequest);

        /// <summary>
        /// Updates a specified product.
        /// </summary>
        /// <param name="id">The properties.</param>
        /// <param name="productRequest">The product request.</param>
        public void Update(int id, string properties);

        /// <summary>
        /// Deletes a specified product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
