using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryAppAPITests.StepDefinitions
{
    /// <summary>
    /// Defines step definitions for Registration feature.
    /// </summary>
    /// <seealso cref="BaseStepDefinitions" />
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

        /// <summary>
        /// Prepares and sets mocks.
        /// </summary>
        [BeforeScenario]
        public void SetMocks() => RegistrationMock.SetMocks();
    }
}
