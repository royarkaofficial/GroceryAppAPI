using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Models.DbModels;

namespace GroceryAppAPI.Models
{
    /// <summary>
    /// Represents a payment.
    /// </summary>
    /// <seealso cref="DbModels.BaseEntity" />
    public class Payment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        /// <value>
        /// The payment type.
        /// </value>
        public PaymentType PaymentType{ get; set; }
    }
}
