using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMM.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GMM.ViewModel;
using GMM.Models;

namespace GMM
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Register connection context objects
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<GmmDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register all necessary interfaces
            services.AddTransient<IBand, vm_band>();            
            services.AddTransient<IBegeleiding, vm_begeleiding>();
            services.AddTransient<IBoeking, vm_boeking>();
            services.AddTransient<IBoekingKleedkamer, vm_boeking_kleedkamer>();
            services.AddTransient<IBoekingProductieEenheid, vm_boeking_productieeenheid>();
            services.AddTransient<ICatering, vm_catering>();
            services.AddTransient<ICommentaar, vm_commentaar>();
            services.AddTransient<ICommentaarType, vm_commentaar_type>();
            services.AddTransient<IFunctie, vm_functie>();
            services.AddTransient<IKleedkamer, vm_kleedkamer>();
            services.AddTransient<IKleurCode, vm_kleurcode>();
            services.AddTransient<IPodium, vm_podium>();
            services.AddTransient<IProductieEenheid, vm_productie_eenheid>();
            services.AddTransient<ITent, vm_tent>();
            services.AddTransient<IVoorziening, vm_voorziening>();

            // Register Identity service
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GmmDbContext>();

            //services.AddIdentity<ApplicationUser, ApplicationRole>(
            //    options => options.Stores.MaxLengthForKeys = 128)
            //    .AddEntityFrameworkStores<GmmDbContext>()
            //    .AddDefaultUI()
            //    .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GmmDbContext pContext)//, RoleManager<ApplicationRole> pRoleManager, UserManager<ApplicationUser> pUserManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //DbIdentityInitializer.Initialize(pContext, pUserManager, pRoleManager).Wait();
            DbInitializer.Initialize(pContext);
        }
    }
}
