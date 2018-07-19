using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SmogInfo.Entities;
using SmogInfo.Services;
using SmogInfo.DataFetchLogic;
using System;

namespace SmogInfo
{
    public class Startup
    {

        public static IConfiguration Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            var connectionString = Startup.Configuration["connectionStrings:smogInfoDBConnectionString"];
            services.AddDbContext<SmogInfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<ISmogInfoRepository, SmogInfoRepository>();

            //services.AddHangfire(config =>
            //config.UseSqlServerStorage(Configuration["connectionStrings:hangfireConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SmogInfoContext smogInfoContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection().UseStaticFiles().UseSpaStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            
            smogInfoContext.EnsureDataForContext();
            
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Entities.City, Model.CitiesWithoutStationsDto>();
                cfg.CreateMap<Entities.City, Model.CitiesDto>();
                cfg.CreateMap<Entities.StationPoint, Model.StationPointDto>();
                cfg.CreateMap<Entities.SmogLevel, Model.SmogLevelDto>();
                cfg.CreateMap<Model.SmogLevelForCreateDto, Entities.SmogLevel>();
            });


            //app.UseHangfireDashboard().UseHangfireServer();

            ///////////////////////////
            ISmogInfoRepository smogInfoRepository = new SmogInfoRepository(smogInfoContext);
            var a = new DataFetch();
            var b = new DataValidation(smogInfoRepository);
            b.CheckForNull(
            b.Deserialize(
            a.ReturnData("http://api.gios.gov.pl/pjp-api/rest/data/getData/3584")));
            b.CompareData(1, 1);
            Console.WriteLine("DONE!!!!!!!!!");

        }
    }
}
