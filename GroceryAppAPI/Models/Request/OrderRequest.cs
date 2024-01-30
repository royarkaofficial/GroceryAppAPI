namespace GroceryAppAPI.Models.Request
{
    /// <summary>
    /// Represents an order request.
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// Gets or sets the product identifiers.
        /// </summary>
        /// <value>
        /// The product identifiers.
        /// </value>
        public IEnumerable<int> ProductIds { get; set; }
    }
}
