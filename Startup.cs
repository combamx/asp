using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Users.Data;

namespace Users
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                //app.UseExceptionHandler(options =>
                //{
                //    options.Run(async context =>
                //    {
                //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        context.Response.ContentType = "text/html";
                //        var ex = context.Features.Get<IExceptionHandlerFeature>();
                //        if(ex != null)
                //        {
                //            var error = $"<h1>Error:{ex.Error.Message}</h1>{ex.Error.StackTrace}";
                //            await context.Response.WriteAsJsonAsync(error).ConfigureAwait(false);
                //        }
                //    });
                //});

                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Codigos de errores
            //app.UseStatusCodePages("text/plain", "Pagina de codigo de estado, codigo de estado: {0}");
            //app.UseStatusCodePages(async context =>
            //{
            //    await context.HttpContext.Response.WriteAsJsonAsync(
            //        "Pagina de codigo de estado, codigo de estado: " + context.HttpContext.Response.StatusCode
            //    );

            //    //await context.HttpContext.Response.WriteAsync(
            //    //    "Pagina de codigo de estado, codigo de estado: " + context.HttpContext.Response.StatusCode 
            //    //);
            //});
            //app.UseStatusCodePagesWithRedirects("/Usuarios/Metodo?code={0}");
            //app.UseStatusCodePagesWithReExecute("/Usuarios/Metodo", "?code={0}");

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute("Usuarios", "Usuario", "{controller=Usuario}/{action=Usuario}/{id?}");

                endpoints.MapRazorPages();

                endpoints.MapGet("Prueba/Index", async context => { 
                    await context.Response.WriteAsync("Hello World!");
                });

            });            
        }
    }
}
