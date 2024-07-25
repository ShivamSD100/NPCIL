using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NPCIL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPCIL
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
            services.AddSingleton<INPCILHelper, NPCILHelper>();
            services.AddSingleton<IDynamicPageHelper, DynamicPageHelper>();
            services.AddSingleton<IPageService, PageService>();
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.AddSingleton<IUrlHelper>(sp =>
            //{
            //    var actionContext = sp.GetService<IActionContextAccessor>().ActionContext;
            //    return new UrlHelper(actionContext);
            //});
            //services.AddScoped<IUrlService, UrlService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/500"); // Redirect to ErrorController action for other errors
                app.UseStatusCodePagesWithReExecute("/Error/{0}"); // Redirect to ErrorController action for 404 errors
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HomePage}/{action=Index}");
            });
        }
    }
}
