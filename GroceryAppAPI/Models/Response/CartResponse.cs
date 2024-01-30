namespace GroceryAppAPI.Models.Response
{
    /// <summary>
    /// Represents the cart response.
    /// </summary>
    public class CartResponse
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the product ids.
        /// </summary>
        /// <value>
        /// The product ids.
        /// </value>
        public IEnumerable<int> ProductIds { get; set; }
    }
}
