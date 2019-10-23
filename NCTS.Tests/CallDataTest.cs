using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class CallDataTest
    {
        private CallDataServices _callDataServices;
        private CallDataTranslator _callDataTranslator;
        public CallDataTest()
        {
            _callDataServices = new CallDataServices();
            _callDataTranslator = new CallDataTranslator();
        }

        [Fact]
        public void Testing_Employee_DB_Model_Return_By_Employee_Translator_Services()
        {
            var callDataProxyModel = _callDataServices.GetProxyObjects().ToList();
            var callDataDbModel = _callDataTranslator.ToModel(callDataProxyModel);
            Assert.IsType<CallData>(callDataDbModel[0]);
        }
    }
}
