using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements business logic for user registration related functionality.
    /// </summary>
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public void Register(User user)
        {
            var existingUser = _userRepository.Get(user.Email);

            if (existingUser != null)
            {
                throw new InvalidRequestException("User is already registered");
            }

            Validate(user);
            user.Password = EncodingHelper.HashPassword(user.Password);
            _userRepository.Add(user);
        }

        /// <summary>
        /// Validates an user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">If user parameter is null.</exception>
        /// <exception cref="GroceryAppAPI.Exceptions.InvalidRequestDataException">If any invalid user property is given.</exception>
        private void Validate(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("User is either not given or invalid.");
            }

            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new InvalidRequestDataException("FirstName is either not given or invalid.");
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new InvalidRequestDataException("LastName is either not given or invalid.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new InvalidRequestDataException("Email is either not given or invalid.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new InvalidRequestDataException("Password is either not given or invalid.");
            }
        }
    }
}
