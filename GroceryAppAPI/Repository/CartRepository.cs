using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for <see cref="Cart"/> entity.
    /// </summary>
    /// <seealso cref="BaseRepository{Cart}" />
    /// <seealso cref="ICartRepository" />
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public CartRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)

        {
        }

        /// <inheritdoc/>
        public int Add(Cart cart)
        {
            const string query = @"INSERT INTO [Carts] ([UserId])
                                   OUTPUT INSERTED.Id
                                   VALUES (@UserId)";
            return Add(query, cart);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Carts] 
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            Update(query, parameters);
        }

        /// <inheritdoc/>
        public Cart Get(int id)
        {
            const string query = @"SELECT * 
                                   FROM [Carts]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return GetAll(query, parameters).FirstOrDefault();
        }

        /// <inheritdoc/>
        public Cart GetByUser(int userId)
        {
            string query = @"SELECT * 
                             FROM [Carts]
                             WHERE [UserId] = @UserId";
            var parameters = new { UserId = userId };
            return GetAll(query, parameters).FirstOrDefault();
        }
    }
}
