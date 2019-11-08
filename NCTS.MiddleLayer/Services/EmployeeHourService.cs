using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Utility;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Services
{
    public class EmployeeHourService : IEmployeeHourService
    {
        private IEmployeeHour _employeeHour;
        private IDatabaseService _databaseService;
        private ILogger _logger;

        public EmployeeHourService(IEmployeeHour employeeHour, IDatabaseService databaseService,ILogger logger)
        {
            _employeeHour = employeeHour;
            _databaseService = databaseService;
            _logger = logger;
        }
        public async Task Pump()
        {
            var employeeHourList = await _employeeHour.GetEmployeeHours();
            _databaseService.InsertEmployeeHours(employeeHourList);
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("EmployeeHour Data is successfully passed to the Database"));

        }
    }
}
