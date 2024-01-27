using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements business logic related to user entity.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public User Get(int id)
        {
            var user = _userRepository.Get(id);

            if (user is null)
            {
                throw new EntityNotFoundException(id, "User");
            }

            return user;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">If user parameter is null.</exception>
        /// <exception cref="InvalidRequestDataException">If any invalid user property is given.</exception>
        public void Update(int id, string password)
        {
            Get(id);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidRequestDataException("Password is either not given or invalid.");
            }

            var hashedPssword = EncodingHelper.HashPassword(password);
            _userRepository.Update(id, hashedPssword);
        }
    }
}
