using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetBlog
{
    public class Startup
    {
        private IConfiguration config;

        public Startup()
        {
            config = new Configuration()
                .AddEnvironmentVariables()
                .AddJsonFile("config.json")
                .AddJsonFile("config.dev.json", true)
                .AddUserSecrets();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<AspNetBlog.Models.BlogDataContext>();
            services.AddScoped<AspNetBlog.Models.Identity.IdentityDataContext>();
            services.AddTransient<AspNetBlog.Models.FormattingService>();

            string blogDataConnectionString = config.Get("Data:BlogData:ConnectionString");
            string identityConnectionString = config.Get("Data:Identity:ConnectionString");

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Models.BlogDataContext>(dbConfig =>
                    dbConfig.UseSqlServer(blogDataConnectionString))
                .AddDbContext<Models.Identity.IdentityDataContext>(dbConfig =>
                    dbConfig.UseSqlServer(identityConnectionString));

            services.AddIdentity<Models.Identity.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Models.Identity.IdentityDataContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            var password = config.Get("password");

            if (config.Get<bool>("RecreateDatabase"))
            {
                var context = app.ApplicationServices.GetService<Models.BlogDataContext>();
                context.Database.EnsureDeleted();
                System.Threading.Thread.Sleep(2000);
                context.Database.EnsureCreated();
            }

            app.UseIdentity();

            if (config.Get<bool>("debug"))
            {
                app.UseErrorPage();
                app.UseRuntimeInfoPage();
            }
            else
            {
                app.UseErrorHandler("/home/error");
            }

            app.UseMvc(routes => routes.MapRoute(
                "Default", "{controller=Home}/{action=Index}/{id?}"));

            app.UseFileServer();
        }
    }
}
