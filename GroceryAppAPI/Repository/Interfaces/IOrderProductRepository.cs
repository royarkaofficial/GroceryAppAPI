using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for order product mapping.
    /// </summary>
    public interface IOrderProductRepository
    {
        /// <summary>
        /// Gets all the products for a specified order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>All products for an order.</returns>
        public IEnumerable<OrderProduct> GetAll(int orderId);

        /// <summary>
        /// Adds the specified order product mapping.
        /// </summary>
        /// <param name="orderProduct">The order product.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(OrderProduct orderProduct);

        /// <summary>
        /// Deletes the order product mapping for specified order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void Delete(int orderId);
    }
}
