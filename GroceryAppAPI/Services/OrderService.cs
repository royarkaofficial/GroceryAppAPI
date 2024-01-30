using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Helpers;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;
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
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="paymentService">The payment service.</param>
        /// <param name="productRepository">The product repository.</param>
        public OrderService(IOrderRepository orderRepository, IUserService userService, IPaymentService paymentService, IProductRepository productRepository, IOrderProductRepository orderProductRepository, IHttpContextAccessor contextAccessor)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _paymentService = paymentService;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _contextAccessor = contextAccessor;
        }

        /// <inheritdoc/>
        public IEnumerable<OrderResponse> GetAll(int userId)
        {
            var user = _userService.Get(userId);
            if (user is null) { throw new InvalidRequestDataException("UserId is either not given or invalid."); }
            IdentityClaimHelper.ClaimUser(user.Email, _contextAccessor);
            var orders =  _orderRepository.GetAll(userId);
            var orderResponses = new List<OrderResponse>();
            foreach (var order in orders)
            {
                var orderProducts = _orderProductRepository.GetAll(order.Id);
                var productIds = orderProducts.Select(op => op.ProductId);
                orderResponses.Add(new OrderResponse() { OrderId = order.Id, ProductIds = productIds });
            }

            return orderResponses;
        }

        /// <inheritdoc/>
        public OrderPlacementResponse Place(int userId, OrderPlacementRequest paymentRequest)
        {
            if (paymentRequest is null) { throw new ArgumentNullException("Payment request is either not given or invalid."); }
            if (paymentRequest.PaymentRequest is null) { throw new InvalidRequestDataException("Payment details is either not given or invalid."); }
            if (paymentRequest.OrderRequest is null) { throw new InvalidRequestDataException("Order details is either not given or invalid."); }
            var orderId = AddOrder(userId, paymentRequest.OrderRequest);
            int paymentId = 0;
            try
            {
                var totalAmount = paymentRequest.OrderRequest.ProductIds.Select(id => _productRepository.Get(id)).Sum(p => p.Price);
                if (totalAmount != paymentRequest.PaymentRequest.Amount) { throw new InvalidRequestDataException("Payment amount is less than total amonut of the purchased items."); }
                paymentId = _paymentService.Add(paymentRequest.PaymentRequest);
            }
            catch (Exception ex)
            {
                _orderProductRepository.Delete(orderId);
                _orderRepository.Delete(orderId);
                throw new PaymentFailedException(ex.Message);
            }
            if (paymentId > 0) { _orderRepository.Update(orderId, paymentId); }
            return new OrderPlacementResponse() { OrderId = orderId, PaymentId = paymentId };
        }

        /// <summary>
        /// Adds the specified order.
        /// </summary>
        /// <param name="orderRequest">The order request.</param>
        /// <returns>The newly inserted identifier.</returns>
        private int AddOrder(int userId, OrderRequest orderRequest)
        {
            if (orderRequest is null) { throw new ArgumentNullException("Order is either null or invalid."); }
            Validate(orderRequest);
            var order = new Order() { UserId = userId };
            var id = _orderRepository.Add(order);
            foreach (var productId in orderRequest.ProductIds)
            {
                var orderProduct = new OrderProduct() { OrderId = id, ProductId = productId };
                _orderProductRepository.Add(orderProduct);
            }
            return id;
        }

        /// <summary>
        /// Validates an order.
        /// </summary>
        /// <param name="orderRequest">The order request.</param>
        /// <exception cref="ArgumentNullException">If order parameter is null.</exception>
        /// <exception cref="InvalidRequestDataException">If any invalid order property is given.</exception>
        private void Validate(OrderRequest orderRequest)
        {
            if (orderRequest is null) { throw new ArgumentNullException("Order is either not given or invalid"); }
            if (orderRequest.ProductIds != null && orderRequest.ProductIds.Any())
            {
                foreach (var productId in orderRequest.ProductIds)
                {
                    var product = _productRepository.Get(productId);
                    if (product is null) { throw new EntityNotFoundException(productId, "Product"); }
                }
            }
            else { throw new InvalidRequestDataException("ProductIds are either not given or invalid."); }
        }
    }
}
