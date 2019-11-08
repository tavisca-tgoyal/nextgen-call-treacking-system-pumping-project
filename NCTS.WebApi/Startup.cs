using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Serilog;
using Tavisca.Common.Plugins.StructureMap;
using Tavisca.Platform.Common.Containers;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Core.ServiceLocator;
using Common.Logging;
using Tavisca.Platform.Common.ExceptionManagement;
using Tavisca.Platform.Common;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSingleton<IConfiguration>(Configuration);
            var serviceLocator = new NetCoreServiceLocator(new ContainerFactory(services), GetModules());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            //Logger.Initialize(new LogWriterFactory());
            //Initalize Logger factor and configure Exception Policy
            Logger.Initialize(ServiceLocator.Current.GetInstance<ILogWriterFactory>());
            ExceptionPolicy.Configure(ServiceLocator.Current.GetInstance<IErrorHandler>());

            var configurationProvider = ServiceLocator.Current.GetInstance<Tavisca.Platform.Common.Configurations.IConfigurationProvider>();
            var serviceProvider = ServiceLocator.Current.GetInstance<IServiceProvider>();

            ServicePointManager.DefaultConnectionLimit = 1000;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //StartLogger();
            return serviceProvider;

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

        private IModule[] GetModules()
        {
            return new IModule[]{
                new Module(),
            };
        }
    }
}
