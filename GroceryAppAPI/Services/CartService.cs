using GroceryAppAPI.Enumerations;
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
    /// Implements cart related functionalities.
    /// </summary>
    /// <seealso cref="ICartService" />
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IUserService _userService;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository.</param>
        /// <param name="cartProductRepository">The cart product repository.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="productRepository">The product repository.</param>
        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IUserService userService, IProductRepository productRepository, IHttpContextAccessor contextAccessor)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
            _userService = userService;
            _productRepository = productRepository;
            _contextAccessor = contextAccessor;
        }

        /// <inheritdoc/>
        public int Add(int userId, CartRequest cartRequest)
        {
            if (cartRequest is null) { throw new ArgumentNullException("Cart is either not given or invalid."); }
            var user = _userService.Get(userId);
            IdentityClaimHelper.ClaimUser(user.Email, _contextAccessor);
            var existingCart = _cartRepository.GetByUser(userId);
            if (existingCart != null) { throw new InvalidRequestException("A cart already exists."); }
            var product = _productRepository.Get(cartRequest.ProductId);
            if (product is null) { throw new EntityNotFoundException(cartRequest.ProductId, "Product"); }
            var cart = new Cart() { UserId = userId };
            var cartId = _cartRepository.Add(cart);
            var cartProduct = new CartProduct() { CartId = cartId, ProductId = cartRequest.ProductId };
            _cartProductRepository.Add(cartProduct);
            return cartId;
        }

        /// <inheritdoc/>
        public CartResponse Get(int userId)
        {
            var user = _userService.Get(userId);
            var cart = _cartRepository.GetByUser(userId);
            if (cart is null) { return null; }
            var cartProducts = _cartProductRepository.GetAll(cart.Id);
            var productIds = cartProducts.Select(x => x.ProductId);
            return new CartResponse { CartId = cart.Id, ProductIds = productIds };
        }

        /// <inheritdoc/>
        public void Delete(int id, int userId)
        {
            var user = _userService.Get(userId);
            IdentityClaimHelper.ClaimUser(user.Email, _contextAccessor);
            _cartProductRepository.Delete(id);
            _cartRepository.Delete(id);
        }

        /// <inheritdoc/>
        public void Update(int id, int userId, CartRequest cartRequest)
        {
            if (cartRequest is null) { throw new ArgumentNullException("Cart is either null or invalid."); }
            var user = _userService.Get(userId);
            IdentityClaimHelper.ClaimUser(user.Email, _contextAccessor);
            var existingCart = _cartRepository.Get(id);
            if (existingCart is null) { throw new EntityNotFoundException(id, "Cart"); }
            var product = _productRepository.Get(cartRequest.ProductId);
            if (product is null) { throw new EntityNotFoundException(cartRequest.ProductId, "Product"); }
            if (!Enum.IsDefined(typeof(CartOperationType), cartRequest.OperationType)) { throw new InvalidRequestDataException("OperationType is either not given or invalid."); }
            if (cartRequest.OperationType is CartOperationType.Add)
            {
                var existingCartProducts = _cartProductRepository.GetAll(id);
                if (existingCartProducts.Select(x => x.ProductId).Contains(cartRequest.ProductId)) { throw new InvalidRequestDataException("Product is already added to the cart."); }
                var cartProduct = new CartProduct() { CartId = id, ProductId = cartRequest.ProductId };
                _cartProductRepository.Add(cartProduct);
            }
            if (cartRequest.OperationType is CartOperationType.Delete) { _cartProductRepository.Delete(id, cartRequest.ProductId); }
            var cartProducts = _cartProductRepository.GetAll(id);
            if (!(cartProducts != null && cartProducts.Any())) { _cartRepository.Delete(id); }
        }
    }
}
