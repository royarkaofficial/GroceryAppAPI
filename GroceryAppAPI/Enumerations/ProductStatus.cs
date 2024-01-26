namespace GroceryAppAPI.Enumerations
{
    /// <summary>
    /// Represents different product status.
    /// </summary>
    public enum ProductStatus
    {
        /// <summary>
        /// The product already exists.
        /// </summary>
        Existing = 1,

        /// <summary>
        /// The product is already removed by an admin.
        /// </summary>
        Removed = 2
    }
}
