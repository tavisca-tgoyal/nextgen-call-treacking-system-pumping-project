using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeTest
    {
        private EmployeeServices _employeeServices;
        public EmployeeTest()
        {
            _employeeServices = new EmployeeServices();
        }

        [Fact]
        public async Task Testing_Employee_DB_Model_Return_By_Employee_Translator_Services()
        {
            var employeeProxyModel = await _employeeServices.GetProxyObjects();
            var employeeDbModel = EmployeeTranslator.ToModel(employeeProxyModel);
            Assert.IsType<Employee>(employeeDbModel[0]);
        }
    }
}
