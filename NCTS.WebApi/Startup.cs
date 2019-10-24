using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.DatabaseServices;
using NCTS.Services.ApiProxyModelServices;
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
            services.AddSingleton<IDatabaseServices, DatabaseService>();
            services.AddSingleton<IEmployeeServices, EmployeeServices>();
            services.AddSingleton<IApplicationServices, ApplicationServices>();
            services.AddSingleton<ICallDataServices, CallDataServices>();
            services.AddSingleton<ICallTreeServices, CallTreeServices>();


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
                .WriteTo.File(@"..\NCTS.Services\Logs\Logging.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
           
        }
    }
}
