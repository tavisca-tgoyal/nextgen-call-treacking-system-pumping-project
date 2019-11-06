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
            Log.Information("Pumping of Employee is executed");
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            _applicationService.Pump();
            Log.Information("Pumping of Application is executed");
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            _callDataService.Pump();
            Log.Information("Pumping of CallData is executed");
        }

        [Route("api/pump/CallTree")]
        public void  PumpCallTree()
        {
            _callTreeService.Pump();
            Log.Information("Pumping of CallTree is executed");
        }

        [Route("api/pump/EmployeeHours")]
        public void PumpEmployeeHours()
        {
            _employeeHourService.Pump();
            Log.Information("Pumping of EmployeeHours is executed");
        }
    }
}