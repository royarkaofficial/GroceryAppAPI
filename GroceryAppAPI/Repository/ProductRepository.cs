using GroceryAppAPI.Configurations;
using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for <see cref="Product"/> enttity.
    /// </summary>
    /// <seealso cref="BaseRepository{Product}" />
    /// <seealso cref="IProductRepository" />
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
            const string query = @"INSERT INTO [Products] ([Name], [Price], [Stock], [ImageUrl], [Status])
                                   OUTPUT INSERTED.Id
                                   VALUES (@Name, @Price, @Stock, @ImageUrl, @Status)";
            var parameters = new
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl,
                Status = product.Status
            };
            return Add(query, parameters);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            const string query = @"DELETE FROM [Products] 
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            Delete(query, parameters);
        }

        /// <inheritdoc/>
        public Product Get(int id)
        {
            const string query = @"SELECT * 
                                   FROM [Products]
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return Get(query, parameters);
        }

        /// <inheritdoc/>
        public IEnumerable<Product> GetAll()
        {
            const string query = @"SELECT *
                                   FROM [Products]";
            return GetAll(query);
        }

        /// <inheritdoc/>
        public void Update(string conditions, Product product)
        {
            string query = @$"UPDATE [Products] 
                                   SET {conditions}
                                   WHERE [Id] = @Id";
            Update(query, product);
        }

        /// <inheritdoc/>
        public void UpdateStatusAsRemoved(int id)
        {
            const string query = @"UPDATE [Products]
                                   SET [Status] = @Status
                                   WHERE [Id] = @Id";
            var parameters = new { Id = id, Status = (int)ProductStatus.Removed };
            Update(query, parameters);
        }
    }
}
