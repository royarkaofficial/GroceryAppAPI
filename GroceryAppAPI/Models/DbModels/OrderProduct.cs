namespace GroceryAppAPI.Models.DbModels
{
    /// <summary>
    /// Represents a order product mapping.
    /// </summary>
    /// <seealso cref="DbModels.BaseEntity" />
    public class OrderProduct : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
    }
}
