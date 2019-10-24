using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class CallTreeTest
    {
        private CallTreeServices _callTreeServices;
        public CallTreeTest()
        {
            _callTreeServices = new CallTreeServices();
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
