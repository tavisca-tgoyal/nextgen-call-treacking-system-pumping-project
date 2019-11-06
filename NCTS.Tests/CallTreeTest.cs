using Moq;
using NCTS.DatabaseMiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Platform.Common.Configurations;
using Xunit;

namespace NCTS.Tests
{
    public class CallTreeTest
    {
        private CallTreeProxyService _callTreeServices;
        //private readonly Mock<IConfigurationProvider> _configurationProvider = new Mock<IConfigurationProvider>();
        private readonly IConfigurationProvider _configurationProvider = new ConfigurationProvider("call_tracking_system");


        public CallTreeTest()
        {
            _callTreeServices = new CallTreeProxyService(_configurationProvider);
        }

        [Fact]
        public async void Testing_CallTree_DB_Model_Return_By_CallTree_Translator_Services()
        {
            var callTreeProxyModel = await _callTreeServices.GetProxyObjects();
            var callTreeDbModel = CallTreeTranslator.ToModel(callTreeProxyModel);
            Assert.IsType<CallTree>(callTreeDbModel[0]);
        }
    }
}
