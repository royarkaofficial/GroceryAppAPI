using GroceryAppAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace GroceryAppAPITests
{
    /// <summary>
    /// Gives the custom implementation of <see cref="WebApplicationFactory{TEntryPoint}"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory{GroceryAppAPI.TestStartup}" />
    public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
    {
        /// <inheritdoc/>
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseEnvironment("Testing")
                    .UseSetting("https_port", "443")
                    .UseStartup<TestStartup>();
            });
        }
    }
}
