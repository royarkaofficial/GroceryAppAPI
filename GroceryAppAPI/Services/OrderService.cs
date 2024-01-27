using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements order related functionalities.
    /// </summary>
    /// <seealso cref="IOrderService" />
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="paymentService">The payment service.</param>
        /// <param name="productRepository">The product repository.</param>
        public OrderService(IOrderRepository orderRepository, IUserService userService, IPaymentService paymentService, IProductRepository productRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _paymentService = paymentService;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
        }

        /// <inheritdoc/>
        public int Add(Order order, bool validatePaymentId = true)
        {
            if (order is null)
            {
                throw new ArgumentNullException("Order is either null or invalid.");
            }

            Validate(order, validatePaymentId);

            var id = _orderRepository.Add(order);

            foreach (var productId in order.ProductIds)
            {
                var orderProduct = new OrderProduct()
                {
                    OrderId = id,
                    ProductId = productId
                };

                _orderProductRepository.Add(orderProduct);
            }

            return id;
        }

        /// <inheritdoc/>
        public IEnumerable<Order> GetAll(int userId)
        {
            var user = _userService.Get(userId);

            if (user is null)
            {
                throw new InvalidRequestDataException("UserId is either not given or invalid.");
            }

            var orders =  _orderRepository.GetAll(userId);

            foreach (var order in orders)
            {
                var orderProducts = _orderProductRepository.GetAll(order.Id);
                order.ProductIds = orderProducts.Select(op => op.ProductId);
            }

            return orders;
        }

        /// <inheritdoc/>
        public (int, int) Pay(int id, PaymentRequest paymentRequest)
        {
            if (paymentRequest is null)
            {
                throw new ArgumentNullException("Payment request is either not given or invalid.");
            }

            if (paymentRequest.Payment is null)
            {
                throw new InvalidRequestDataException("Payment details is either not given or invalid.");
            }

            if (paymentRequest.Order is null)
            {
                throw new InvalidRequestDataException("Order details is either not given or invalid.");
            }

            var orderId = Add(paymentRequest.Order, false);
            int paymentId = 0;

            try
            {
                var totalAmount = paymentRequest.Order.ProductIds.Select(id => _productRepository.Get(id)).Sum(p => p.Price);

                if (totalAmount != paymentRequest.Payment.Amount)
                {
                    throw new InvalidRequestDataException("Payment amount is less than total amonut of the purchased items.");
                }

                paymentId = _paymentService.Add(paymentRequest.Payment);
            }
            catch (Exception ex)
            {
                _orderProductRepository.Delete(orderId);
                _orderRepository.Delete(orderId);
                throw new PaymentFailedException(ex.Message);
            }

            if (paymentId > 0)
            {
                _orderRepository.Update(orderId, paymentId);
            }
            
            return (orderId, paymentId);
        }

        /// <summary>
        /// Validates an order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="validatePaymentId">Boolean flag which indicates whether to validate the payment identifier or not.</param>
        /// <exception cref="System.ArgumentNullException">If order parameter is null.</exception>
        /// <exception cref="GroceryAppAPI.Exceptions.InvalidRequestDataException">If any invalid order property is given.</exception>
        private void Validate(Order order, bool validatePaymentId)
        {
            if (order is null)
            {
                throw new ArgumentNullException("Order is either not given or invalid");
            }

            var user = _userService.Get(order.UserId);

            try
            {
                var payment = _paymentService.Get(order.PaymentId);
            }
            catch (Exception)
            {
                if (validatePaymentId)
                {
                    throw;
                }
            }

            if (order.ProductIds != null && order.ProductIds.Any())
            {
                foreach (var productId in order.ProductIds)
                {
                    var product = _productRepository.Get(productId);

                    if (product is null)
                    {
                        throw new EntityNotFoundException(productId, "Product");
                    }
                }
            }
            else
            {
                throw new InvalidRequestDataException("ProductIds are either not given or invalid.");
            }
        }
    }
}
