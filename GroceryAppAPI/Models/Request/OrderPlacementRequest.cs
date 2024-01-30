namespace GroceryAppAPI.Models.Request
{
    /// <summary>
    /// Represents an order placement request.
    /// </summary>
    public class OrderPlacementRequest
    {
        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        public PaymentRequest PaymentRequest { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public OrderRequest OrderRequest { get; set; }
    }
}
