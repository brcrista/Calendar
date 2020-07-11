using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Calendar.DataAccess;
using Calendar.ObjectModel.DataProviders;

namespace Calendar.WebService
{
    /// <summary>
    /// Exposes methods that get called on application startup.
    /// </summary>
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Injects dependencies into the app container.
        /// </summary>
        /// <remarks>
        /// This method gets called on startup by the ASP.NET runtime.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseFilepath = Path.Join(Directory.GetCurrentDirectory(), "calendar.db");

            // Check for the database file early.
            if (!File.Exists(databaseFilepath))
            {
                throw new FileNotFoundException($"Database file {databaseFilepath} does not exist.");
            }

            services
                .AddSingleton(sp => new SqliteDatabaseContext(databaseFilepath))
                .AddSingleton<AccountsTableAccess>()
                .AddSingleton<UsersTableAccess>()
                .AddSingleton<EventsTableAccess>()
                .AddSingleton<IUsersProvider, SqliteUsersProvider>()
                .AddSingleton<IEventsProvider, SqliteEventsProvider>()
                .AddControllersWithViews(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = false;
                });
        }

        /// <summary>
        /// Adds middleware to the HTTP request pipeline.
        /// </summary>
        /// <remarks>
        /// This method gets called on startup by the ASP.NET runtime.
        /// </remarks>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
