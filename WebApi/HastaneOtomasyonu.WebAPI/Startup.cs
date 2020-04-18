using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.Bussiness.Concreate;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.DataAccess.Concreat.Entityframework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HastaneOtomasyonu.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //DataAccess service
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBolumRepository, BolumRepository>();
            services.AddTransient<IDoktorRepository, DoktorRepository>();
            services.AddTransient<IHastaneRepository,HastaneRepository>();
            services.AddTransient<IHastaRepository, HastaRepository>();
            services.AddTransient<IIlRepository, IlRepository>();
            services.AddTransient<IRandevuRepository, RandevuRepository>();
            //Bussiness service
            services.AddTransient<IAdminService, AdminManager>();
            services.AddTransient<IBolumService, BolumManager>();
            services.AddTransient<IDoktorService, DoktorManager>();
            services.AddTransient<IHastaneService, HastaneManager>();
            services.AddTransient<IHastaService, HastaManager>();
            services.AddTransient<IIlService, IlManager>();
            services.AddTransient<IRandevuService, RandevuManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
