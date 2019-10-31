using Moq;
using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeTest
    {
        private EmployeeServices _employeeServices;
        private readonly Mock<IConfigurationProvider> _configurationProvider = new Mock<IConfigurationProvider>();
        public EmployeeTest()
        {
            _employeeServices = new EmployeeServices(_configurationProvider.Object);
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
