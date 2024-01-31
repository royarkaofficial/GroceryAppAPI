using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        public UserResponse Get(int id);
        public void Update(int id, string properties);
        public void UpdatePassword(ResetPasswordRequest resetPasswordRequest);
    }
}
