using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Utility;
using Serilog;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Services
{
    public class EmployeeHourService : IEmployeeHourService
    {
        private IEmployeeHour _employeeHour;
        private IDatabaseService _databaseService;

        public EmployeeHourService(IEmployeeHour employeeHour, IDatabaseService databaseService)
        {
            _employeeHour = employeeHour;
            _databaseService = databaseService;
        }
        public async Task Pump()
        {
            var employeeHourList = await _employeeHour.GetEmployeeHours();
            _databaseService.InsertEmployeeHours(employeeHourList);

            Log.Information("EmployeeHour Data is successfully passed to the DBLayer");
        }
    }
}
