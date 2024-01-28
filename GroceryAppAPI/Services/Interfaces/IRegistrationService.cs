using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

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
        public RegistrationResponse Register(RegistrationRequest registrationRequest);
    }
}
