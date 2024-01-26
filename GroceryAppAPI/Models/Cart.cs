using GroceryAppAPI.Enumerations;

namespace GroceryAppAPI.Models
{
    /// <summary>
    /// Represents a cart creation request.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Models.BaseEntity" />
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        public CartOperationType OperationType { get; set; }
    }
}
