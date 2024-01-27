namespace GroceryAppAPI.Enumerations
{
    /// <summary>
    /// Specifies different payment option types.
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// The cash on delivery.
        /// </summary>
        CashOnDelivery = 1,

        /// <summary>
        /// The UPI.
        /// </summary>
        UPI = 2,

        /// <summary>
        /// The Credit Card.
        /// </summary>
        CreditCard = 3,

        /// <summary>
        /// The NEFT.
        /// </summary>
        NEFT = 4,

        /// <summary>
        /// The wallet.
        /// </summary>
        Wallet = 5
    }
}
