using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Repository.Interfaces
{
    /// <summary>
    /// Abstracts database utilities for <see cref="Payment"/> entity.
    /// </summary>
    public interface IPaymentRepository
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
