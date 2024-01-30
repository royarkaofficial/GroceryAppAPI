namespace GroceryAppAPI.Models.Response
{
    /// <summary>
    /// Represents the order placement response.
    /// </summary>
    public class OrderPlacementResponse
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public int PaymentId { get; set; }
    }
}
