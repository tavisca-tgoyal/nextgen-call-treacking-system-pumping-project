using Microsoft.AspNetCore.Mvc;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using Serilog;

namespace NCTS.WebApi.Controllers
{

    [ApiController]
    public class PumpController : ControllerBase
    {

        private ICallDataService _callDataService;
        private ICallTreeService _callTreeService;
        private IEmployeeService _employeeService;
        private IApplicationService _applicationService;
        private IEmployeeHourService _employeeHourService;

        public PumpController(ICallDataService callDataService,ICallTreeService callTreeService, IEmployeeService employeeService, IApplicationService applicationService, IEmployeeHourService employeeHourService)
        {
            _callDataService = callDataService;
            _callTreeService = callTreeService;
            _employeeService = employeeService;
            _applicationService = applicationService;
            _employeeHourService = employeeHourService;
        }

        [Route("api/pump/employee")]
        public void PumpEmployees()
        {
            _employeeService.Pump();
            Log.Information("Employee Data is passed to Database Layer Successfully");
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            _applicationService.Pump();
            Log.Information("Application data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            _callDataService.Pump();

            Log.Information("Call data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallTree")]
        public void  PumpCallTree()
        {
            _callTreeService.Pump();

            Log.Information("CallTree data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/EmployeeHours")]
        public void PumpEmployeeHours()
        {
            _employeeHourService.Pump();
            Log.Information("EmployeeHour data is Passed to Database Layer Successfully");
        }
    }
}