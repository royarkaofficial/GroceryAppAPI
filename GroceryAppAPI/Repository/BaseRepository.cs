using Dapper;
using Microsoft.Data.SqlClient;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements all the basic database utilities .
    /// </summary>
    /// <typeparam name="T">The typeparameter.</typeparam>
    public class BaseRepository<T>
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets all the entities of a specific type.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters. Default value is <c>null</c>.</param>
        /// <returns>The entities.</returns>
        public IEnumerable<T> GetAll(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(query, parameters);
            }
        }


        /// <summary>
        /// Adds a specific entity to the table.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The newly inserted identifier.</returns>
        public int Add(string query, object parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<int>(query, parameters);
            }
        }

        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        public void Execute(string query, object parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.QueryFirstOrDefault<int>(query, parameters);
            }
        }
    }
}
