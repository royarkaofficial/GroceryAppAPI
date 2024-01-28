namespace GroceryAppAPI.Models.DbModels
{
    /// <summary>
    /// Repreents a cart product mapping.
    /// </summary>
    /// <seealso cref="DbModels.BaseEntity" />
    public class CartProduct : BaseEntity
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }
    }
}
