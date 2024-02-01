using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements business logic for user registration related functionality.
    /// </summary>
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public void Register(RegistrationRequest registrationRequest)
        {
            Validate(registrationRequest);
            registrationRequest.Password = EncodingHelper.HashPassword(registrationRequest.Password);
            var user = new User()
            {
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Email = registrationRequest.Email,
                Password = registrationRequest.Password,
                Address = registrationRequest.Address,
                Gender = (int)registrationRequest.Gender,
                Role = (int)registrationRequest.Role
            };
            _userRepository.Add(user);
        }

        /// <summary>
        /// Validates a registration request.
        /// </summary>
        /// <param name="registrationRequest">The registration request.</param>
        private void Validate(RegistrationRequest registrationRequest)
        {
            if (registrationRequest is null) { throw new ArgumentNullException("User is either not given or invalid."); }
            if (string.IsNullOrWhiteSpace(registrationRequest.FirstName)) { throw new InvalidRequestDataException("FirstName is either not given or invalid."); }
            if (string.IsNullOrWhiteSpace(registrationRequest.LastName)) { throw new InvalidRequestDataException("LastName is either not given or invalid."); }
            if (string.IsNullOrWhiteSpace(registrationRequest.Email)) { throw new InvalidRequestDataException("Email is either not given or invalid."); }
            if (string.IsNullOrWhiteSpace(registrationRequest.Password)) { throw new InvalidRequestDataException("Password is either not given or invalid."); }
            if (string.IsNullOrWhiteSpace(registrationRequest.Address)) { throw new InvalidRequestDataException("Address is either not given or invalid."); }
            if (!Enum.IsDefined(typeof(Gender), registrationRequest.Gender)) { throw new InvalidRequestDataException("Gender is either not given or invalid."); }
            if (!Enum.IsDefined(typeof(Role), registrationRequest.Role)) { throw new InvalidRequestDataException("Role is either not given or invalid."); }
            var existingUser = _userRepository.Get(registrationRequest.Email);
            if (existingUser != null) { throw new InvalidRequestException("An user is already registered with the same email."); }
        }
    }
}
