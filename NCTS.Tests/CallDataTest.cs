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
        public CallDataTest()
        {
            _callDataServices = new CallDataServices();
        }

        [Fact]
        public void Testing_CallData_DB_Model_Return_By_CallData_Translator_Services()
        {
            var callDataProxyModel = _callDataServices.GetProxyObjects().ToList();
            var callDataDbModel = CallDataTranslator.ToModel(callDataProxyModel);
            Assert.IsType<CallData>(callDataDbModel[0]);
        }
    }
}
