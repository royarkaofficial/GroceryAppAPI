using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)
        {
        }
        public User Get(int id)
        {
            const string query = @"SELECT *
                                   FROM [Users]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return Get(query, parameters);
        }
        public User Get(string email)
        {
            const string query = @"SELECT *
                                   FROM [Users]
                                   WHERE [Email] = @Email";
            var parameters = new { Email = email };
            return GetAll(query, parameters).FirstOrDefault();
        }
        public void Update(string conditions, User user)
        {
            string query = @$"UPDATE [Users]
                              SET {conditions}
                              WHERE [Id] = @Id";
            Update(query, user);
        }
        public void Update(int id, string passwordHash)
        {
            const string query = @"UPDATE [Users]
                                   SET [Password] = @Password";
            var parameters = new { Password = passwordHash };
            Update(query, parameters);
        }
        public int Add(User user)
        {
            const string query = @"INSERT INTO [Users] ([FirstName], [LastName], [Email], [Password], [Address], [Gender], [Role])
                                   OUTPUT INSERTED.Id
                                   VALUES (@FirstName, @LastName, @Email, @Password, @Address, @Gender, @Role)";
            return Add(query, user);
        }
    }
}
