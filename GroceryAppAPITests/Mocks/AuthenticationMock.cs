using GroceryAppAPI.Helpers.Interfaces;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Services;
using Moq;
using Newtonsoft.Json;

namespace GroceryAppAPITests.Mocks
{
    public static class AuthenticationMock
    {
        private static string BasePath = Environment.CurrentDirectory + "/TestData/";
        public static Mock<IUserRepository> UserRepositoryMock = new Mock<IUserRepository>();
        public static Mock<IJwtTokenHelper> JwtTokenHelperMock = new Mock<IJwtTokenHelper>();
        public static void SetMocks()
        {
            MockUserRepository();
            MockJwtTokenHelper();
        }
        private static void MockUserRepository()
        {
            UserRepositoryMock.Setup(repo => repo.Get(It.IsAny<string>())).Returns((string email) =>
            {
                var fileContent = File.ReadAllText(BasePath + "users.json");
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(fileContent);
                return users.FirstOrDefault(user => user.Email == email);
            });
        }

        private static void MockJwtTokenHelper()
        {
            JwtTokenHelperMock.Setup(helper => helper.GenerateAccessToken(It.IsAny<User>())).Returns("Mock_Access_Token");
        }
    }
}
