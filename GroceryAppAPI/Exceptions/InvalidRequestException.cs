namespace GroceryAppAPI.Exceptions
{
    /// <summary>
    /// Represents an error which occurs when a service is requested with invalid request data.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class InvalidRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidRequestException(string message)
            : base(message)
        {   
        }
    }
}
