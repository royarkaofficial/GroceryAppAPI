using GroceryAppAPI.Configurations;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Repository;
using GroceryAppAPI.Services.Interfaces;
using GroceryAppAPI.Services;

namespace GroceryAppAPI
{
    /// <summary>
    /// Initializes the API project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>A host builder object.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}