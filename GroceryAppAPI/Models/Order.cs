using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Models
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    /// <seealso cref="DbModels.BaseEntity" />
    public class Order : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId {  get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>
        /// The payment identifier.
        /// </value>
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the ordered at.
        /// </summary>
        /// <value>
        /// The ordered at.
        /// </value>
        public DateTime OrderedAt { get; set; }

        /// <summary>
        /// Gets or sets the product ids.
        /// </summary>
        /// <value>
        /// The product ids.
        /// </value>
        public IEnumerable<int> ProductIds { get; set; }

    }
}