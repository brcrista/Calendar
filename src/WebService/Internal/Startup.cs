using System;
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
    internal sealed class Startup
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
            var databaseFilepath = Configuration["Data:DatabaseFile"];

            // Check for the database file early.
            if (databaseFilepath == null)
            {
                throw new ArgumentNullException("No database file was given in the configuration.");
            }

            if (!File.Exists(databaseFilepath))
            {
                throw new FileNotFoundException($"Database file {databaseFilepath} does not exist.");
            }

            services
                .AddSingleton(sp => new SqliteDatabaseContext(databaseFilepath))
                .AddSingleton<AccountsTableAccess>()
                .AddSingleton<UsersTableAccess>()
                .AddSingleton<EventsTableAccess>()
                .AddSingleton<UserEventsTableAccess>()
                .AddSingleton<IUsersProvider, SqliteUsersProvider>()
                .AddSingleton<IEventsProvider, SqliteEventsProvider>()
                .AddSingleton<IUserEventsProvider, SqliteUserEventsProvider>()
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
