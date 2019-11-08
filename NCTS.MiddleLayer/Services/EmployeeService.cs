using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;

namespace NCTS.MiddleLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeProxyService _employeeProxyService;
        private IDatabaseService _databaseService;
        private ILogger _logger;
        public EmployeeService(IEmployeeProxyService employeeProxyService, IDatabaseService databaseService,ILogger logger)
        {
            _employeeProxyService = employeeProxyService;
            _databaseService = databaseService;
            _logger = logger;
        }

        public async void Pump()
        {
            var employeeList =  await _employeeProxyService.GetProxyObjects();
            _databaseService.InsertEmployees(employeeList.ToModel());
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Employee Data is successfully passed to the Database"));
        }
    }
}
