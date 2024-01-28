using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Models.Response
{
    /// <summary>
    /// Represents the response model for an <see cref="User"/>.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role { get; set; }
    }
}
