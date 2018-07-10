using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmogInfo.Entities;
using SmogInfo.Services;
using SmogInfo.SmogLevelsLogic;
using System.IO;

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
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc()
                .AddMvcOptions(o=>o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
            

            var connectionString = Startup.Configuration["connectionStrings:smogInfoDBConnectionString"];
            services.AddDbContext<SmogInfoContext>(o=>o.UseSqlServer(connectionString));
            services.AddScoped<ISmogInfoRepository,SmogInfoRepository>();

            services.AddHangfire(config=>
            config.UseSqlServerStorage(Configuration["connectionStrings:hangfireConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SmogInfoContext smogInfoContext)
        {
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            smogInfoContext.EnsureDataForContext();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Entities.City, Model.CitiesWithoutStationsDto>();
                cfg.CreateMap<Entities.City, Model.CitiesDto>();
                cfg.CreateMap<Entities.StationPoint, Model.StationPointDto>();
                cfg.CreateMap<Entities.SmogLevel, Model.SmogLevelDto>();
                cfg.CreateMap<Model.SmogLevelForCreateDto, Entities.SmogLevel>();
                });
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            DataProcessing.Run();

        }
    }
}
