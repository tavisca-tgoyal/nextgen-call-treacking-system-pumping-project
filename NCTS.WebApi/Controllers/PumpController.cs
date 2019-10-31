using Microsoft.AspNetCore.Mvc;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Utility;
using NCTS.Proxy.Interfaces;
using Serilog;

namespace NCTS.WebApi.Controllers
{

    [ApiController]
    public class PumpController : ControllerBase
    {
        private IDatabaseService _databaseServices;
        private IEmployeProxyService _employeeServices;
        private IApplicationProxyService _applicationServices;
        private ICallDataProxyService _callDataServices;
        private ICallTreeProxyService _callTreeServices;
        private IEmployeeHour _employeeHour;

        public PumpController(IDatabaseService databaseService, IEmployeProxyService employeeServices, IApplicationProxyService applicationServices, ICallDataProxyService callDataServices, ICallTreeProxyService callTreeServices,IEmployeeHour employeeHour)
        {
            _databaseServices = databaseService;
            _employeeServices = employeeServices;
            _applicationServices = applicationServices;
            _callDataServices = callDataServices;
            _callTreeServices = callTreeServices;
            _employeeHour = employeeHour;
        }

        [Route("api/pump/employee")]
        public void PumpEmployees()
        {
            _databaseServices.InsertEmployees(_employeeServices);

            Log.Information("Employee Data is passed to Database Layer Successfully");
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            _databaseServices.InsertApplications(_applicationServices);

            Log.Information("Application data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            _databaseServices.InsertCallData(_callDataServices);

            Log.Information("Call data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallTree")]
        public void  PumpCallTree()
        {
            _databaseServices.InsertCallTrees(_callTreeServices);

            Log.Information("CallTree data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/EmployeeHours")]
        public void PumpEmployeeHours()
        {
            _databaseServices.InsertEmployeeHours(_employeeHour);

            Log.Information("EmployeeHour data is Passed to Database Layer Successfully");
        }
    }
}