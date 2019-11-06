using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using Serilog;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeProxyService _employeeProxyService;
        private IDatabaseService _databaseService;
        public EmployeeService(IEmployeeProxyService employeeProxyService, IDatabaseService databaseService)
        {
            _employeeProxyService = employeeProxyService;
            _databaseService = databaseService;
        }

        public async Task Pump()
        {
            var employeeList =  await _employeeProxyService.GetProxyObjects();
            _databaseService.InsertEmployees(employeeList.ToModel());

            Log.Information("Employee Data is successfully passed to the DBLayer");
        }
    }
}
