using NCTS.DatabaseMiddleLayer.Model;
using NCTS.MiddleLayer.Utility;
using System.Threading.Tasks;
using Xunit;

namespace NCTS.Tests
{
    public class EmployeeHourTest
    {
        private EmployeeHour _employeeHour;
        public EmployeeHourTest()
        {
            _employeeHour = new EmployeeHour();
        }

        [Fact]
        public async Task Testing_EmployeeHour_DB_Model_Return_By_EmployeeHour_Translator_Services()
        {
            var employeeHourDbModel =await _employeeHour.GetEmployeeHours();
            Assert.IsType<EmployeeHours>(employeeHourDbModel[0]);
        }
    }
}
