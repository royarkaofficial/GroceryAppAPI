using GroceryAppAPI.Models.Request;
using GroceryAppAPI.Models.Response;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public LoginResponse Login(LoginRequest loginRequest);
    }
}
