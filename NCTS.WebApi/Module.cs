using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Aws;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Containers;

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
        }
    }
}
