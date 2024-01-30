namespace GroceryAppAPI.Models.Response
{
    /// <summary>
    /// Represents the order response.
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the product identifiers.
        /// </summary>
        /// <value>
        /// The product identifiers.
        /// </value>
        public IEnumerable<int> ProductIds { get; set; }
    }
}
