using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

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
        public IEnumerable<OrderResponse> GetAll(int userId);

        /// <summary>
        /// Places the specified order.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns>The newly inserted order and payment identifier.</returns>
        public OrderPlacementResponse Place(int userId, OrderPlacementRequest paymentRequest);
    }
}
