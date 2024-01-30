namespace GroceryAppAPI.Models.DbModels
{
    /// <summary>
    /// Represents a cart.
    /// </summary>
    /// <seealso cref="BaseEntity" />
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
    }
}
