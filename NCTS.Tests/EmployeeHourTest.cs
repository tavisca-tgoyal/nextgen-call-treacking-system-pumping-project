using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using NCTS.Services.Utility;
using System;
using System.Linq;
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
        public void Testing_EmployeeHour_DB_Model_Return_By_EmployeeHour_Translator_Services()
        {
            var employeeHourDbModel = _employeeHour.GetEmployeeHours();
            Assert.IsType<EmployeeHours>(employeeHourDbModel[0]);
        }
    }
}
