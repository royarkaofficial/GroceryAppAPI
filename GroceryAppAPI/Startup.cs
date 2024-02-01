using GroceryAppAPI.Configurations;
using GroceryAppAPI.Repository.Interfaces;
using GroceryAppAPI.Repository;
using GroceryAppAPI.Services.Interfaces;
using GroceryAppAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GroceryAppAPI
{
    /// <summary>
    /// Configures application before running.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsConfiguration = Configuration.GetSection("AppSettings");
            var connectionStringConfiguration = appSettingsConfiguration.GetSection("ConnectionString");
            services.Configure<ConnectionString>(connectionStringConfiguration);
            services.AddTransient<ICartProductRepository, CartProductRepository>();
            services.AddTransient<IOrderProductRepository, OrderProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["AppSettings:Authentication:Issuer"],
                    ValidAudience = Configuration["AppSettings:Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:Authentication:Key"]))
                };
            });
            services.AddControllers();
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application info.</param>
        /// <param name="env">The running environment info.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
