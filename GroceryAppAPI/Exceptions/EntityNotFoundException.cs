namespace GroceryAppAPI.Exceptions
{
    /// <summary>
    /// Represents an error which occurs when an entity is not found.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        public EntityNotFoundException(int id, string entityName)
            :base($"{entityName} with id {id} is not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EntityNotFoundException(string message)
            :base(message)
        {            
        }
    }
}
