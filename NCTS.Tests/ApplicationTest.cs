using NCTS.MiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class ApplicationTest
    {
        private ApplicationProxyService _applicationServices;
        public ApplicationTest()
        {
            _applicationServices = new ApplicationProxyService();
        }

        [Fact]
        public void Testing_Application_DB_Model_Return_By_Application_Translator_Services()
        {
            var appplicationProxyModel = _applicationServices.GetProxyObjects().ToList();
            var applicationDbModel = ApplicationTranslator.ToModel(appplicationProxyModel);
            Assert.IsType<Application>(applicationDbModel[0]);
        }
    }
}
