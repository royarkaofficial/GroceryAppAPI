using GroceryAppAPI.Models;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts payment related functionalities.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Gets the specified payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The payment.</returns>
        public Payment Get(int id);

        /// <summary>
        /// Adds the specified payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(Payment payment);
    }
}
