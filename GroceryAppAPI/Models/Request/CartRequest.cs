using GroceryAppAPI.Enumerations;

namespace GroceryAppAPI.Models.Request
{
    /// <summary>
    /// Represents a cart request.
    /// </summary>
    public class CartRequest
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        /// <value>
        /// The operation type.
        /// </value>
        public CartOperationType OperationType { get; set; }
    }
}
