using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for order entity.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Repository.BaseRepository&lt;GroceryAppAPI.Models.Order&gt;" />
    /// <seealso cref="GroceryAppAPI.Repository.Interfaces.IOrderRepository" />
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public OrderRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)

        {
        }

        /// <inheritdoc/>
        public int Add(Order order)
        {
            const string query = @"INSERT INTO [Orders] ([UserId], [OrderedAt])
                                   OUTPUT INSERTED.Id
                                   VALUES (@UserId, GETUTCDATE())";

            return Add(query, order);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Orders]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };

            Execute(query, parameters);
        }

        /// <inheritdoc/>
        public IEnumerable<Order> GetAll(int userId)
        {
            const string query = @"SELECT *
                                   FROM [Orders]
                                   WHERE [UserId] = @UserId
                                   AND [PaymentId] IS NOT NULL";
            var parameters = new { UserId = userId };

            return GetAll(query, parameters);
        }

        /// <inheritdoc/>
        public void Update(int id, int paymentId)
        {
            const string query = @"UPDATE [Orders]
                                   SET [PaymentId] = @PaymentId
                                   WHERE [Id] = @Id";
            var parameters = new {Id = id, PaymentId = paymentId };

            Execute(query, parameters);
        }
    }
}
