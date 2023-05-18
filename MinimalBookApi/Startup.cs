using MinimalBookApi.Database;
using MySql.Data.MySqlClient;

namespace MinimalBookApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MySqlConnection>(_ =>
                new MySqlConnection(Configuration.GetConnectionString("Default")));
            services.AddSingleton<DatabaseManager>();
            // Add any other services your application requires
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the application...
        }

    }
}
