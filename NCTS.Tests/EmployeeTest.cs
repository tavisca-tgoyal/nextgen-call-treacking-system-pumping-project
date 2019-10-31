using NCTS.MiddleLayer.Model;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.ProxyServices;
using System.Threading.Tasks;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeTest
    {
        private EmployeeProxyService _employeeServices;
        public EmployeeTest()
        {
            _employeeServices = new EmployeeProxyService();
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
