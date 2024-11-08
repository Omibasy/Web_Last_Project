using Microsoft.AspNetCore;

namespace Web_Last_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = CreateWebHostBuilder(args);
            IWebHost webHost = builder.Build();

            webHost.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder hostBulder = WebHost.CreateDefaultBuilder(args);

            hostBulder.UseStartup<Startup>();
      

            return hostBulder;
        }
    }
}