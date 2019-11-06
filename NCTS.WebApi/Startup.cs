using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Services;
using NCTS.MiddleLayer.Utility;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using Serilog;

namespace NCTS.WebApi
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

            services.AddSingleton<ICallDataService, CallDataService>();
            services.AddSingleton<ICallTreeService, CallTreeService>();
            services.AddSingleton<IApplicationService, ApplicationService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeHourService, EmployeeHourService>();

            services.AddSingleton<IDatabaseService, DatabaseService>();

            services.AddSingleton<IApplicationProxyService, ApplicationProxyService>();
            services.AddSingleton<ICallDataProxyService, CallDataProxyService>();
            services.AddSingleton<ICallTreeProxyService, CallTreeProxyService>();
            services.AddSingleton<IEmployeeProxyService, EmployeeProxyService>();
            services.AddSingleton<IEmployeeHour, EmployeeHour>();

            StartLogger();

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

        private void StartLogger()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("../Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
    }
}
