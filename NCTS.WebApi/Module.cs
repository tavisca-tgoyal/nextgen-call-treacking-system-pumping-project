using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Services;
using NCTS.MiddleLayer.Utility;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using System;
using System.Collections.Generic;
using Tavisca.Common.Plugins.Aws;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Common.Plugins.Redis;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Containers;
using Tavisca.Platform.Common.Logging;

namespace NCTS.WebApi
{
    public class Module : IModule
    {

        public IEnumerable<Registration> GetRegistrations()
        {
            var remoteConfigurationStore = new ConsulConfigurationStore();
            var sensitiveDataProvider = new ParameterStoreProvider();
            new ConfigurationBuilder()
                .WithRemoteStore(remoteConfigurationStore)
                .WithSensitiveDataProvider(sensitiveDataProvider)
                .Apply();

            yield return Registration.AsSingleton<IConfigurationStore>(() => remoteConfigurationStore, KeyStore.Configuration.RemoteStore);
            yield return Registration.AsSingleton<ISensitiveDataProvider>(() => sensitiveDataProvider, KeyStore.Configuration.SensitiveDataProvider);
            Func<IConfigurationProvider> configurationProvider = () => new ConfigurationProvider(KeyStore.ApplicationName);
            yield return Registration.AsSingleton<IConfigurationProvider>(() => configurationProvider.Invoke());
            yield return Registration.AsPerCall<ILogWriterFactory, LogWriterFactory>();
            yield return Registration.AsSingleton<IDatabaseService, DatabaseService>();
            yield return Registration.AsSingleton<IEmployeeService, EmployeeService>();
            yield return Registration.AsSingleton<IApplicationService, ApplicationService>();
            yield return Registration.AsSingleton<ICallDataService, CallDataService>();
            yield return Registration.AsSingleton<ICallTreeService, CallTreeService>();
            yield return Registration.AsSingleton<IEmployeeHourService, EmployeeHourService>();
            yield return Registration.AsSingleton<IApplicationProxyService, ApplicationProxyService>();
            yield return Registration.AsSingleton<ICallDataProxyService, CallDataProxyService>();
            yield return Registration.AsSingleton<ICallTreeProxyService, CallTreeProxyService>();
            yield return Registration.AsSingleton<IEmployeeProxyService, EmployeeProxyService>();
            yield return Registration.AsSingleton<IEmployeeHour, EmployeeHour>();
            yield return Registration.AsSingleton<ILogger, ServiceLogger>();
            yield return Registration.AsPerCall<IRedisLogSettingsProvider, RedisSettingsProvider>();
            yield return Registration.AsSingleton<ILogSink, RedisSink>();
        }
    }
}
