using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature ="User")]
    public class UserStepDefinitions : BaseStepDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public UserStepDefinitions(CustomWebApplicationFactory applicationFactory)
            : base(applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => UserMock.UserRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public void SetMocks()
        {
            UserMock.SetMocks();
        }
    }
}
