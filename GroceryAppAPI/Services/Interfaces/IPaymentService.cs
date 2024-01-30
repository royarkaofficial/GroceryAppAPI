using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;

namespace GroceryAppAPI.Services.Interfaces
{
    /// <summary>
    /// Abstracts payment related functionalities.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Adds the specified payment.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(PaymentRequest paymentRequest);
    }
}
