using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Product")]
    public class ProductStepDefinitions : BaseStepDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public ProductStepDefinitions(CustomWebApplicationFactory applicationFactory)
            : base(applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => ProductMock.ProductRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public void SetMocks()
        {
            ProductMock.SetMocks();
        }
    }
}
