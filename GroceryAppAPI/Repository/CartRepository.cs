using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)

        {
        }
        public int Add(Cart cart)
        {
            const string query = @"INSERT INTO [Carts] ([UserId])
                                   OUTPUT INSERTED.Id
                                   VALUES (@UserId)";
            return Add(query, cart);
        }
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Carts] 
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            Update(query, parameters);
        }
        public Cart Get(int id)
        {
            const string query = @"SELECT * 
                                   FROM [Carts]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return GetAll(query, parameters).FirstOrDefault();
        }
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
