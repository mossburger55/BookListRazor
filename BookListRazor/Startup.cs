using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //dependancy injection
        public void ConfigureServices(IServiceCollection services)
        {
            //.AddRazorRuntimeCompilation() is no longer available for 6.0.6 version of RuntimeCompilation NugetPackage
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //NET Core Runtimes are the smallest self-contained and specific component and contain the absolute 
        //minimum to run just.NET Core on a specific platform.Note it a runtime install does not include the ASP.NET Core meta package runtime dependencies

        //Configuration = instanciate IIS => Runtime (CLR) => 
        //https://www.youtube.com/watch?v=C5cnZ-gZy2I&t=761s
        //Whatch 46:00 for more in details

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            //Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app's executable endpoints. 
            //Endpoints are the app's units of executable request - handling code.Endpoints are defined in the app and configured 
            //when the app starts.The endpoint matching process can extract values from the request's URL and provide those values for request processing. 
            //Using endpoint information from the app, routing is also able to generate URLs that map to endpoints.
        }
    }
}
