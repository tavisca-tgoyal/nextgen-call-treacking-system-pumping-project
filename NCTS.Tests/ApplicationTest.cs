using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class ApplicationTest
    {
        private ApplicationServices _applicationServices;
        public ApplicationTest()
        {
            _applicationServices = new ApplicationServices();
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
