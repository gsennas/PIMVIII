using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PimVIII.Data;
using PimVIII.Services;

namespace PimVIII
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<PimVIIIContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("PimVIIIContext"), builder =>
                        builder.MigrationsAssembly("PimVIII")));

            services.AddScoped<SeedingService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<TelefoneService>();
            services.AddScoped<PessoaService>();
            services.AddScoped<PessoaPAO>();
            services.AddScoped<EnderecoRepository>();
            services.AddScoped<TelefoneRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seeding)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seeding.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pessoas}/{action=Index}/{id?}");
            });
        }
    }
}
