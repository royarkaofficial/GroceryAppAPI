using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface ICartService
    {
        public CartResponse Get(int userId);
        public int Add(int userId, CartRequest cartRequest);
        public void Delete(int id, int userId);
        public void Update(int id, int userId, CartRequest cartRequest);
    }
}
