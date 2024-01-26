using GroceryAppAPI.Models;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for order entity.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets all the orders.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The orders.</returns>
        public IEnumerable<Order> GetAll(int userId);

        /// <summary>
        /// Adds the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public int Add(Order order);

        /// <summary>
        /// Updates the payment identifier of the specified order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="paymentId">The payment identifier.</param>
        public void Update(int id, int paymentId);

        /// <summary>
        /// Deletes the specified payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id);
    }
}
