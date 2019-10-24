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
        private CallTreeTranslator _callDataTranslator;
        public CallTreeTest()
        {
            _callTreeServices = new CallTreeServices();
            _callDataTranslator = new CallTreeTranslator();
        }

        [Fact]
        public void Testing_CallTree_DB_Model_Return_By_CallTree_Translator_Services()
        {
            var callTreeProxyModel = _callTreeServices.GetProxyObjects().ToList();
            var callTreeDbModel = _callDataTranslator.ToModel(callTreeProxyModel);
            Assert.IsType<CallTree>(callTreeDbModel[0]);
        }
    }
}
