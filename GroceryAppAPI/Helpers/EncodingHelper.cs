using System.Security.Cryptography;
using System.Text;

namespace GroceryAppAPI.Helpers
{
    /// <summary>
    /// A helper class for encoding strings.
    /// </summary>
    public static class EncodingHelper
    {
        /// <summary>
        /// Generate the 256 bit hash of a password using SHA-256 bit.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Password hash.</returns>
        public static string HashPassword(string password)
        {
            var encodedPassword = Encoding.UTF8.GetBytes(password);
            var passwordHash = SHA256.HashData(encodedPassword);
            return Convert.ToBase64String(passwordHash);
        }
    }
}
