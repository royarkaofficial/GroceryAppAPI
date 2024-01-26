using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements authentication related functionalities.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Services.Interfaces.IAuthenticationService" />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public void Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new InvalidRequestDataException("Username is either not given or invalid.");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new InvalidRequestDataException("Password is either not given or invalid.");
            }

            var user = _userRepository.Get(request.Username);
            var actualHash = user.Password;
            var expectedHash = EncodingHelper.HashPassword(request.Password);

            if (actualHash != expectedHash)
            {
                throw new InvalidRequestException("Password is incorrect.");
            }
        }
    }
}
