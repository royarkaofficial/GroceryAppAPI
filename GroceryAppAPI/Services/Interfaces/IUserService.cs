using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstract business logic for user entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user response.</returns>
        public UserResponse Get(int id);

        /// <summary>
        /// Updates the details of a specified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="properties">The properties.</param>
        public void Update(int id, string properties);

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="resetPasswordRequest">The reset password request.</param>
        public void UpdatePassword(ResetPasswordRequest resetPasswordRequest);
    }
}
