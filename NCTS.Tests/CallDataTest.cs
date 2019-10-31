using NCTS.MiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class CallDataTest
    {
        private CallDataProxyService _callDataServices;
        public CallDataTest()
        {
            _callDataServices = new CallDataProxyService();
        }

        [Fact]
        public void Testing_CallData_DB_Model_Return_By_CallData_Translator_Services()
        {
            var callDataProxyModel = _callDataServices.GetProxyObjects().ToList();
            var callDataDbModel = callDataProxyModel.ToModel();
            Assert.IsType<CallData>(callDataDbModel[0]);
        }
    }
}
