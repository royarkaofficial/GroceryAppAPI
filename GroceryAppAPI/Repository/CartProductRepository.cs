using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database operations for cart product mapping (represented by <see cref="CartProduct"/>).
    /// </summary>
    /// <seealso cref="BaseRepository{CartProduct}" />
    /// <seealso cref="ICartProductRepository" />
    public class CartProductRepository : BaseRepository<CartProduct>, ICartProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartProductRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public CartProductRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)
        {
        }

        /// <inheritdoc/>
        public void Delete(int cartId, int productId)
        {
            const string query = @"DELETE FROM [Carts_Products] 
                                   WHERE [CartId] = @CartId
                                   AND [ProductId] = @ProductId";
            var parameters = new { CartId = cartId, ProductId = productId };
            Update(query, parameters);
        }

        /// <inheritdoc/>
        public IEnumerable<CartProduct> GetAll(int cartId)
        {
            const string query = @"SELECT *
                                   FROM [Carts_Products]
                                   WHERE [CartId] = @CartId";
            var parameters = new { CartId = cartId };
            return GetAll(query, parameters);
        }

        /// <inheritdoc/>
        public void Add(CartProduct cartProduct)
        {
            const string query = @"INSERT INTO [Carts_Products] ([CartId], [ProductId])
                                   OUTPUT INSERTED.Id
                                   VALUES (@CartId, @ProductId)";
            Add(query, cartProduct);
        }

        /// <inheritdoc/>
        public void Delete(int cartId)
        {
            const string query = @"DELETE FROM [Carts_Products]
                                   WHERE [CartId] = @CartId";
            var parameters = new { CartId = cartId };
            Delete(query, parameters);
        }
    }
}
