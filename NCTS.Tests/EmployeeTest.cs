using Moq;
using NCTS.DatabaseMiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using System.Threading.Tasks;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Platform.Common.Configurations;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeTest
    {
        private EmployeeProxyService _employeeServices;
        //private readonly Mock<IConfigurationProvider> _configurationProvider = new Mock<IConfigurationProvider>();
        private readonly IConfigurationProvider _configurationProvider = new ConfigurationProvider("call_tracking_system");

        public EmployeeTest()
        {
            _employeeServices = new EmployeeProxyService(_configurationProvider);
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
