using GroceryAppAPI.Configurations;
using GroceryAppAPI.Models.DbModels;
using GroceryAppAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace GroceryAppAPI.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IOptions<ConnectionString> connectionString)
           : base(connectionString.Value.DefaultConnection)
        {
        }
        public int Add(Payment payment)
        {
            const string query = @"INSERT INTO [Payments] ([Amount], [PaymentType])
                                   OUTPUT INSERTED.Id
                                   VALUES (@Amount, @PaymentType)";
            return Add(query, payment);
        }
        public Payment Get(int id)
        {
            const string query = @"SELECT * FROM 
                                   [Payments] WHERE [Id] = @Id";
            var parameters = new { Id = id };
            return GetAll(query, parameters).FirstOrDefault();
        }
    }
}
