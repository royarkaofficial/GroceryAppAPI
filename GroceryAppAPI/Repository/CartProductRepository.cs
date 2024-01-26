using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database operations for cart product mapping.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Repository.BaseRepository&lt;GroceryAppAPI.Models.DbModels.CartProduct&gt;" />
    /// <seealso cref="GroceryAppAPI.Repository.Interfaces.ICartProductRepository" />
    public class CartProductRepository : BaseRepository<CartProduct>, ICartProductRepository
    {
        public CartProductRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)
        {
        }

        /// <inheritdoc/>
        public void Delete(int id, int productId)
        {
            const string query = @"DELETE FROM [Carts_Products] 
                                   WHERE [CartId] = @Id
                                   AND [ProductId] = @ProductId";
            var parameters = new { Id = id, ProductId = productId };

            Execute(query, parameters);
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
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Carts_Products]
                                   WHERE [CartId] = @CartId";
            var parameters = new { CartId = id };

            Execute(query, parameters);
        }
    }
}
