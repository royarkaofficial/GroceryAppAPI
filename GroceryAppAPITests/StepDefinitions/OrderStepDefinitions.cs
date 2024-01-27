using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryAppAPITests.StepDefinitions
{
    /// <summary>
    /// Defines step definitions for Order feature.
    /// </summary>
    /// <seealso cref="BaseStepDefinitions" />
    [Binding]
    [Scope(Feature = "Order")]
    public class OrderStepDefinitions : BaseStepDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public OrderStepDefinitions(CustomWebApplicationFactory applicationFactory)
            : base(applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => OrderMock.OrderRepositoryMock.Object);
                    services.AddTransient(_ => OrderMock.UserRepositoryMock.Object);
                    services.AddTransient(_ => OrderMock.PaymentRepositoryMock.Object);
                    services.AddTransient(_ => OrderMock.ProductRepositoryMock.Object);
                    services.AddTransient(_ => OrderMock.OrderProductRepositoryMock.Object);
                });
            }))
        {
        }

        /// <summary>
        /// Prepares and sets mocks.
        /// </summary>
        [BeforeScenario]
        public void SetMocks() => OrderMock.SetMocks();
    }
}
