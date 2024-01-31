using GroceryAppAPI.Models.Request;

namespace GroceryAppAPI.Services.Interfaces
{
    public interface IRegistrationService
    {
        public void Register(RegistrationRequest registrationRequest);
    }
}
