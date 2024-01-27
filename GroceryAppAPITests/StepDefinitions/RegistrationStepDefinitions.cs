using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Registration")]
    public class RegistrationStepDefinitions : BaseStepDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public RegistrationStepDefinitions(CustomWebApplicationFactory applicationFactory)
            : base(applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => RegistrationMock.UserRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public void SetMocks()
        {
            RegistrationMock.SetMocks();
        }
    }
}
