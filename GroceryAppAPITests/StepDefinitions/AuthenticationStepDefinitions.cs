using GroceryAppAPITests.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Authentication")]
    public class AuthenticationStepDefinitions : BaseStepDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public AuthenticationStepDefinitions(CustomWebApplicationFactory applicationFactory)
            : base(applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => AuthenticationMock.UserRepositoryMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public void SetupMock()
        {
            AuthenticationMock.SetMocks();
        }
    }
}
