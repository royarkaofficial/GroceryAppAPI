using GroceryAppAPI.Enumerations;

namespace GroceryAppAPI.Models.Request
{
    /// <summary>
    /// Represents a payment request.
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        /// <value>
        /// The payment type.
        /// </value>
        public PaymentType PaymentType { get; set; }
    }
}
