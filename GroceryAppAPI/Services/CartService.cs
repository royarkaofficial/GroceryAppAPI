using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Exceptions;
using GroceryAppAPI.Models;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Response;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services.Interfaces;

namespace GroceryAppAPI.Services
{
    /// <summary>
    /// Implements cart related functionalities.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Services.Interfaces.ICartService" />
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IUserService _userService;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository.</param>
        /// <param name="cartProductRepository">The cart product repository.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="productRepository">The product repository.</param>
        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IUserService userService, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
            _userService = userService;
            _productRepository = productRepository;
        }

        /// <inheritdoc/>
        public int Add(Models.Cart cart)
        {
            if (cart is null)
            {
                throw new ArgumentNullException("Cart is either not given or invalid.");
            }

            var user = _userService.Get(cart.UserId);
            var existingCart = _cartRepository.GetByUser(userId: cart.UserId);

            if (existingCart != null)
            {
                throw new InvalidRequestException("A cart already exists.");
            }

            var product = _productRepository.Get(cart.ProductId);

            if (product is null)
            {
                throw new EntityNotFoundException(cart.ProductId, "Product");
            }

            var cartId = _cartRepository.Add(cart);
            
            var cartProduct = new CartProduct()
            {
                CartId = cartId,
                ProductId = cart.ProductId
            };

            _cartProductRepository.Add(cartProduct);
            return cartId;
        }

        /// <inheritdoc/>
        public Models.Response.Cart Get(int userId)
        {
            var user = _userService.Get(userId);
            var cart = _cartRepository.GetByUser(userId);
            
            if (cart is null)
            {
                return null;
            }

            var cartProducts = _cartProductRepository.GetAll(cart.Id);
            var productIds = cartProducts.Select(x => x.ProductId);
            return new Models.Response.Cart()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ProductIds = productIds
            };
        }

        /// <inheritdoc/>
        public void Delete(int id, int userId)
        {
            _userService.Get(userId);
            IsCartBelongToTheUser(id, userId);
            _cartProductRepository.Delete(id);
            _cartRepository.Delete(id);
        }

        /// <inheritdoc/>
        public void Update(int id, Models.Cart cart)
        {
            if (cart is null)
            {
                throw new ArgumentNullException("Cart is either null or invalid.");
            }

            var existingCart = _cartRepository.Get(id);

            if (existingCart is null)
            {
                throw new EntityNotFoundException(id, "Cart");
            }

            IsCartBelongToTheUser(id, cart.UserId);
            _userService.Get(cart.UserId);

            var product = _productRepository.Get(cart.ProductId);

            if (product is null)
            {
                throw new EntityNotFoundException(cart.ProductId, "Product");
            }

            if (!Enum.IsDefined(typeof(CartOperationType), cart.OperationType))
            {
                throw new InvalidRequestDataException("OperationType is either not given or invalid.");
            }

            if (cart.OperationType is CartOperationType.Add)
            {
                var existingCartProducts = _cartProductRepository.GetAll(id);

                if (existingCartProducts.Select(x => x.ProductId).Contains(cart.ProductId))
                {
                    throw new InvalidRequestDataException("Product is already added to the cart.");
                }

                var cartProduct = new CartProduct()
                {
                    CartId = id,
                    ProductId = cart.ProductId
                };

                _cartProductRepository.Add(cartProduct);
            }

            if (cart.OperationType is CartOperationType.Delete)
            {
                _cartProductRepository.Delete(id, cart.ProductId);
            }

            var cartProducts = _cartProductRepository.GetAll(id);

            if (!(cartProducts != null && cartProducts.Any()))
            {
                _cartRepository.Delete(id);
            }
        }

        /// <summary>
        /// Determines whether the cart belongs to the user or not.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// <c>true</c> if the cart belongs to the user; otherwise, throws <see cref="InvalidRequestDataException"/>.
        /// </returns>
        /// <exception cref="GroceryAppAPI.Exceptions.InvalidRequestDataException">Cart does not belong to the user.</exception>
        private bool IsCartBelongToTheUser(int cartId, int userId)
        {
            var existingCart = _cartRepository.Get(cartId);
            var existingCartOfTheUser = _cartRepository.GetByUser(userId);

            if (existingCart != null && existingCart.Id != existingCartOfTheUser.Id)
            {
                throw new InvalidRequestDataException("Cart does not belong to the user.");
            }

            return true;
        }
    }
}
