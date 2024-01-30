using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements payment related functionalities.
    /// </summary>
    /// <seealso cref="IPaymentService" />
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        /// <param name="paymentRepository">The payment repository.</param>
        /// <param name="paymentTypeService">The payment type service.</param>
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        /// <inheritdoc/>
        public int Add(PaymentRequest paymentRequest)
        {
            Validate(paymentRequest);
            var payment = new Payment() { Amount = paymentRequest.Amount, PaymentType = (int)paymentRequest.PaymentType };
            return _paymentRepository.Add(payment);
        }

        /// <summary>
        /// Validates a payment.
        /// </summary>
        /// <param name="paymentRequest">The payment.</param>
        /// <exception cref="ArgumentNullException">If payment parameter is null.</exception>
        /// <exception cref="InvalidRequestDataException">If any invalid payment property is given.</exception>
        public void Validate(PaymentRequest paymentRequest)
        {
            if (paymentRequest is null) { throw new ArgumentNullException("Payment is either not given or invalid."); }
            if (paymentRequest.Amount <= 0) { throw new InvalidRequestDataException("Amount is either not given or invalid."); }
            if (!Enum.IsDefined(typeof(PaymentType), paymentRequest.PaymentType)) { throw new InvalidRequestDataException("PaymentType is either not given or invalid."); }
        }
    }
}
