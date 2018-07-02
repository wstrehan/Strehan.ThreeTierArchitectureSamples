using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using Strehan.DataAccess;

namespace CoreSample
{
    public class StockStartup
    {
        public IConfiguration Configuration { get; }

        public StockStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //Handles Database Access and creation of return object - Injected into StockController
            services.AddSingleton<IStockServiceHelper, StockServiceHelper>((ctx) =>
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                IDataAccess dataAccess = new SqlDataAccess(new SProcNameResolution(), connectionString);
                return new StockServiceHelper(dataAccess);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Allows Default.html to be called
            app.UseStaticFiles();
          

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
