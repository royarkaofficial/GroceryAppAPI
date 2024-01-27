using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts order related functionalities.
    /// </summary>
    public interface IOrderService
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
        /// <returns>The newly inserted identifier.</returns>
        public int AddOrder(Order order);

        /// <summary>
        /// Adds payment for the specified order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns>The newly inserted order and payment identifier.</returns>
        public (int, int) Pay(int id, PaymentRequest paymentRequest);
    }
}
