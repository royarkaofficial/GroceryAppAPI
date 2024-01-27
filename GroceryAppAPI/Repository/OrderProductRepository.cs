using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for order product mapping (represented by <see cref="OrderProduct"/>).
    /// </summary>
    /// <seealso cref="BaseRepository{OrderProduct}" />
    /// <seealso cref="IOrderProductRepository" />
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProductRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public OrderProductRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)
        {
        }

        /// <inheritdoc/>
        public int Add(OrderProduct orderProduct)
        {
            const string query = @"INSERT INTO [Orders_Products] ([OrderId], [ProductId])
                                   OUTPUT INSERTED.Id
                                   VALUES (@OrderId, @ProductId)";
            
            return Add(query, orderProduct);
        }

        /// <inheritdoc/>
        public IEnumerable<OrderProduct> GetAll(int orderId)
        {
            const string query = @"SELECT *
                                   FROM [Orders_Products]
                                   WHERE [OrderId] = @OrderId";
            var parameters = new { OrderId = orderId };

            return GetAll(query, parameters);
        }

        /// <inheritdoc/>
        public void Delete(int orderId)
        {
            const string query = @"DELETE FROM [Orders_Products] 
                                   WHERE [OrderId] = @OrderId";
            var parameters = new {OrderId = orderId};

            Delete(query, parameters);
        }
    }
}
