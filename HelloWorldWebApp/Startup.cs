using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using MyService;
using Microsoft.Framework.Caching.Memory;

namespace HelloWorldWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            this.Configuration = configuration;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable Cache-able Partial View.
            services.AddSingleton<IMemoryCache, MemoryCache>();

            // Enable Entity Framework 7.
            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<NorthwindDataContext>();

            // Enable MVC 6.
            services.AddMvc();

            // Enable Logging Service.
            services.AddLogging();

            // Dependency Injection.
            services.AddScoped<IServiceComponent, MyServiceComponent2>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            //app.UseErrorPage();
            //app.UseRuntimeInfoPage();
            //app.UseStaticFiles();
            //app.UseDirectoryBrowser();

            loggerfactory.AddConsole(LogLevel.Warning);

            app.UseMvc(route =>
            {
                route.MapRoute(
                    "default", 
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" });
            });            
        }
    }
}
