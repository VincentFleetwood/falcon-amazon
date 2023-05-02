
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FalconAmazonRestAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // Constructor that receives IConfiguration
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Retrieve the connection string from appsettings.json
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Add the DbContext to the dependency injection container
            services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app)
        {
            // The Configure method is used to configure the HTTP request pipeline.
            // Here you can add middleware components, such as authentication and routing.
        }
    }
}