using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Helpers.Interfaces
{
    public interface IJwtTokenHelper
    {
        public string GenerateAccessToken(User user);
    }
}
