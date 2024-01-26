using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for product enttity.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Repository.BaseRepository&lt;GroceryAppAPI.Models.Product&gt;" />
    /// <seealso cref="GroceryAppAPI.Repository.Interfaces.IProductRepository" />
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ProductRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.DefaultConnection) 
        {
        }

        /// <inheritdoc/>
        public int Add(Product product)
        {
            const string query = @"INSERT INTO [Products] ([Name], [Price], [Stock], [ImageUrl])
                                   OUTPUT INSERTED.Id
                                   VALUES (@Name, @Price, @Stock, @ImageUrl)";

            return Add(query, product);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Products] 
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };

            Execute(query, parameters);
        }

        /// <inheritdoc/>
        public Product Get(int id)
        {
            const string query = @"SELECT * 
                                   FROM [Products]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };

            return GetAll(query, parameters).FirstOrDefault();
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetAll()
        {
            const string query = @"SELECT *
                                   FROM [Products]";

            return GetAll(query);
        }

        /// <inheritdoc/>
        public void Update(int id, Product product)
        {
            const string query = @"UPDATE [Products] 
                                   SET [Name] = @Name,
                                   [Price] = @Price,
                                   [Stock] = @Stock,
                                   [ImageUrl] = @ImageUrl";

            Execute(query, product);
        }
    }
}
