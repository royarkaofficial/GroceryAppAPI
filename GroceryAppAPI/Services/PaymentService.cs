using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements payment related functionalities.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Services.Interfaces.IPaymentService" />
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
        public int Add(Payment payment)
        {
            Validate(payment);

            return _paymentRepository.Add(payment);
        }

        /// <inheritdoc/>
        public Payment Get(int id)
        {
            var payment = _paymentRepository.Get(id);

            if (payment is null)
            {
                throw new EntityNotFoundException(id, "Payment");
            }

            return payment;
        }

        /// <summary>
        /// Validates a payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <exception cref="ArgumentNullException">If payment parameter is null.</exception>
        /// <exception cref="GroceryAppAPI.Exceptions.InvalidRequestDataException">If any invalid payment property is given.</exception>
        public void Validate(Payment payment)
        {
            if (payment is null)
            {
                throw new ArgumentNullException("");
            }

            if (payment.Amount <= 0)
            {
                throw new InvalidRequestDataException("Amount is either not given or invalid.");
            }

            if (!Enum.IsDefined(typeof(PaymentType), payment.PaymentType))
            {
                throw new InvalidRequestDataException("PaymentType is either not given or invalid.");
            }
        }
    }
}
