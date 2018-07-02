using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CoreSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args).UseStartup<StockStartup>();
            IWebHost webHost = webHostBuilder.Build();
            webHost.Run();
        }

    }
}
