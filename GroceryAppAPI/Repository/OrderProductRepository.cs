using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)
        {
        }
        public int Add(OrderProduct orderProduct)
        {
            const string query = @"INSERT INTO [Orders_Products] ([OrderId], [ProductId])
                                   OUTPUT INSERTED.Id
                                   VALUES (@OrderId, @ProductId)";
            return Add(query, orderProduct);
        }
        public IEnumerable<OrderProduct> GetAll(int orderId)
        {
            const string query = @"SELECT *
                                   FROM [Orders_Products]
                                   WHERE [OrderId] = @OrderId";
            var parameters = new { OrderId = orderId };
            return GetAll(query, parameters);
        }
        public void Delete(int orderId)
        {
            const string query = @"DELETE FROM [Orders_Products] 
                                   WHERE [OrderId] = @OrderId";
            var parameters = new {OrderId = orderId};
            Delete(query, parameters);
        }
    }
}
