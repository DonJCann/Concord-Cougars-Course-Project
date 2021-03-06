//Team Concord Cougars
//Teresa Lord, Donavan Cann, Paige Ferguson, Chandler Howland, Richard Rademann, Melissa Richardson
//CISS 411
//Software Architechture and Testing
//Sprint 1 started: 6/7/2022
//Sprint 2 started: 6/15/2022

using Concord_Cougars_Course_Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Concord_Cougars_Course_Project

{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection =
                @"Server=(localdb)\mssqllocaldb;Database=SwimSchoolDb;
                    Trusted_Connection=True;";
            services.AddDbContext<SwimSchoolDbContext>
                (options => options.UseSqlServer(connection));
            services.AddIdentity<ApplicationUser, IdentityRole>()  //Added for Identity - Entity is ApplicationUser class model
                .AddEntityFrameworkStores<SwimSchoolDbContext>()  //Added for Identity
                .AddDefaultTokenProviders();                      //Added for Identity
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();  //Added for Identity
            app.UseAuthorization();   //Added for Identity
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
