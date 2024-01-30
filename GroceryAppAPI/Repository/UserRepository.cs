using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for <see cref="User"/> entity.
    /// </summary>
    /// <seealso cref="BaseRepository{User}" />
    /// <seealso cref="IUserRepository" />
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public UserRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection)

        {
        }

        /// <inheritdoc/>
        public User Get(int id)
        {
            const string query = @"SELECT *
                                   FROM [Users]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return Get(query, parameters);
        }

        /// <inheritdoc/>
        public User Get(string email)
        {
            const string query = @"SELECT *
                                   FROM [Users]
                                   WHERE [Email] = @Email";
            var parameters = new { Email = email };
            return GetAll(query, parameters).FirstOrDefault();
        }

        /// <inheritdoc/>
        public void Update(int id, string password)
        {
            const string query = @"UPDATE [Users]
                                   SET [Password] = @Password
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id, Password =  password };
            Update(query, parameters);
        }

        /// <inheritdoc/>
        public int Add(User user)
        {
            const string query = @"INSERT INTO [Users] ([FirstName], [LastName], [Email], [Password], [Gender], [Role])
                                   OUTPUT INSERTED.Id
                                   VALUES (@FirstName, @LastName, @Email, @Password, @Gender, @Role)";
            return Add(query, user);
        }
    }
}
