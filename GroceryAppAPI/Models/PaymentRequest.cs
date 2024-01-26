namespace GroceryAppAPI.Models
{
    /// <summary>
    /// Represents a payment request for an order.
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        public Payment Payment { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public Order Order { get; set; }
    }
}
