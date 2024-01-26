namespace GroceryAppAPI.Exceptions
{
    /// <summary>
    /// Represents an error which occurs when the payment for an order fails.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class PaymentFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFailedException"/> class.
        /// </summary>
        public PaymentFailedException()
            : base("Payment failed for the order. Order can't be placed")
        {
        }
    }
}
