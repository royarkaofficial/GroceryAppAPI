namespace GroceryAppAPI.Exceptions
{
    /// <summary>
    /// Represents an error which occurs when an invalid request data is given.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class InvalidRequestDataException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestDataException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidRequestDataException(string message)
            : base(message) 
        {
        }
    }
}
