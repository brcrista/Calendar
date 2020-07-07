using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Calendar.DataAccess;
using Calendar.ObjectModel.DataProviders;

namespace Calendar.ApiService
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Reuse a single DB connection.
                .AddSingleton(serviceProvider => SqliteDataReader.ConnectAsync(@"C:\Users\Brian\Code\GitHub\brcrista\Calendar\calendar.db").Result)
                //.AddSingleton(serviceProvider => SqliteDataReader.ConnectAsync("calendar.db").Result)
                .AddSingleton<EventsTableAccess>()
                .AddSingleton<IUsersProvider, MemoryUsersProvider>()
                .AddSingleton<IEventsProvider, SqliteEventsProvider>()
                .AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
