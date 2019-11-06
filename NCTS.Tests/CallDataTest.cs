using Moq;
using NCTS.DatabaseMiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using System.Linq;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Platform.Common.Configurations;
using Xunit;

namespace NCTS.Tests
{
    public class CallDataTest
    {
        private CallDataProxyService _callDataServices;

        //private readonly Mock<IConfigurationProvider> _configurationProvider = new Mock<IConfigurationProvider>();

        private readonly IConfigurationProvider _configurationProvider = new ConfigurationProvider("call_tracking_system");



        public CallDataTest()
        {
            _callDataServices = new CallDataProxyService(_configurationProvider);
        }

        [Fact]
        public async void Testing_CallData_DB_Model_Return_By_CallData_Translator_Services()
        {
            var callDataProxyModel = await _callDataServices.GetProxyObjects();
            var callDataDbModel = callDataProxyModel.ToModel();
            Assert.IsType<CallData>(callDataDbModel[0]);
        }
    }
}
