using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models.Response;
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
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Initializes a new instance of <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="contextAccessor">The HTTP context accessor.</param>
        public UserService(IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        /// <inheritdoc/>
        public UserResponse Get(int id)
        {
            var user = _userRepository.Get(id);
            IdentityClaimHelper.ClaimUser(user.Email, _contextAccessor);

            if (user is null)
            {
                throw new EntityNotFoundException(id, "User");
            }

            return new UserResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = (Role)user.Role
            };
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidRequestDataException">Password is either not given or invalid.</exception>
        public void Update(int id, string password)
        {
            Get(id);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidRequestDataException("Password is either not given or invalid.");
            }

            var hashedPassword = EncodingHelper.HashPassword(password);
            _userRepository.Update(id, hashedPassword);
        }
    }
}
