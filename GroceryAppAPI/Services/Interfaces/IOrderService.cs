using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderResponse> GetAll(int userId);
        public OrderPlacementResponse Place(int userId, OrderPlacementRequest paymentRequest);
    }
}
