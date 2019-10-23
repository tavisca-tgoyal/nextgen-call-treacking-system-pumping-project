using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Linq;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeTest
    {
        private EmployeeServices _employeeServices;
        private EmployeeTranslator _employeeTranslator;
        public EmployeeTest()
        {
            _employeeServices = new EmployeeServices();
            _employeeTranslator = new EmployeeTranslator();
        }

        [Fact]
        public void Testing_Employee_DB_Model_Return_By_Employee_Translator_Services()
        {
            var employeeProxyModel = _employeeServices.GetProxyObjects().ToList();
            var employeeDbModel = _employeeTranslator.ToModel(employeeProxyModel);
            Assert.IsType<Employee>(employeeDbModel[0]);
        }
    }
}
