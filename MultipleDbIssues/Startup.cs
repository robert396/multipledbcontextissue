using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultipleDbIssues.Data;

namespace MultipleDbIssues
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClientDbContext>(opts =>
            {
                opts.UseMySql("Server=localhost; Port=3306; Database=sample_clients; Uid=root; Pwd=*passwordgoeshere*;");
            });

            services.AddDbContext<SiteDbContext>(opts =>
            {
                opts.UseMySql("Server=localhost; Port=3306; Database=sample_sites; Uid=root; Pwd=*passwordgoeshere*;");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var clientDbContext = scope.ServiceProvider.GetService<ClientDbContext>();
                clientDbContext.Database.Migrate();
                var siteDbContext = scope.ServiceProvider.GetService<SiteDbContext>();
                var migrator = siteDbContext.Database.GetService<IMigrator>();
                siteDbContext.Database.Migrate();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
