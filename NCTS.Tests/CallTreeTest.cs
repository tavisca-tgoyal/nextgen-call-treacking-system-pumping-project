using NCTS.DatabaseMiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using Xunit;

namespace NCTS.Tests
{
    public class CallTreeTest
    {
        private CallTreeProxyService _callTreeServices;
        public CallTreeTest()
        {
            _callTreeServices = new CallTreeProxyService();
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
