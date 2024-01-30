using GroceryAppAPI.Models.Request;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts registration related functionalities.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// Registers an user.
        /// </summary>
        /// <param name="registrationRequest">The registration request.</param>
        /// <returns>The registration response.</returns>
        public void Register(RegistrationRequest registrationRequest);
    }
}
