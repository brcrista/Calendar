using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Calendar.ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(Configure)
                .Build()
                .Run();
        }

        public static void Configure(IWebHostBuilder webBuilder)
        {
            webBuilder.UseStartup<Startup>();
        }
    }
}
