using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Models.Request;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        public int Add(PaymentRequest paymentRequest);
    }
}
