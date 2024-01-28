using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Models.Response
{
    /// <summary>
    /// Represents a cart response.
    /// </summary>
    /// <seealso cref="DbModels.BaseEntity" />
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
        /// Gets or sets the product ids.
        /// </summary>
        /// <value>
        /// The product ids.
        /// </value>
        public IEnumerable<int> ProductIds { get; set; }
    }
}
