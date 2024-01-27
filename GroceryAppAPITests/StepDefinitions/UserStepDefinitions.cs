using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryAppAPITests.StepDefinitions
{
    /// <summary>
    /// Defines step definitions for User feature.
    /// </summary>
    /// <seealso cref="BaseStepDefinitions" />
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

        /// <summary>
        /// Prepares and sets mocks.
        /// </summary>
        [BeforeScenario]
        public void SetMocks() => UserMock.SetMocks();
    }
}
