using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    /// <summary>
    /// Implements database utilities for payment entity.
    /// </summary>
    /// <seealso cref="GroceryAppAPI.Repository.BaseRepository&lt;GroceryAppAPI.Models.Payment&gt;" />
    /// <seealso cref="GroceryAppAPI.Repository.Interfaces.IPaymentRepository" />
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public PaymentRepository(IOptions<ConnectionString> connectionString)
           : base(connectionString.Value.DefaultConnection)
        {
        }

        /// <inheritdoc/>
        public int Add(Payment payment)
        {
            const string query = @"INSERT INTO [Payments] ([Amount], [PaymentType])
                                   OUTPUT INSERTED.Id
                                   VALUES (@Amount, @PaymentType)";

            return Add(query, payment);
        }

        /// <inheritdoc/>
        public Payment Get(int id)
        {
            const string query = @"SELECT * FROM 
                                   [Payments] WHERE [Id] = @Id";
            var parameters = new { Id = id };

            return GetAll(query, parameters).FirstOrDefault();
        }
    }
}
