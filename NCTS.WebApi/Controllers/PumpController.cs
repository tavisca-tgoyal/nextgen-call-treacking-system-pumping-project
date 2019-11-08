using Microsoft.AspNetCore.Mvc;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using Common.Logging;

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
        private ILogger _logger;

        public PumpController(ICallDataService callDataService,ICallTreeService callTreeService, IEmployeeService employeeService, IApplicationService applicationService, IEmployeeHourService employeeHourService,ILogger logger)
        {
            _callDataService = callDataService;
            _callTreeService = callTreeService;
            _employeeService = employeeService;
            _applicationService = applicationService;
            _employeeHourService = employeeHourService;
            _logger = logger;
        }

        [Route("api/pump/employee")]
        public async void PumpEmployees()
        {
            _employeeService.Pump();
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Pumping of Employee is executed"));
        }

        [Route("api/pump/Application")]
        public async void PumpApplication()
        {
            _applicationService.Pump();
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Pumping of Application is executed"));
        }

        [Route("api/pump/CallData")]
        public async void PumpCallData()
        {
            _callDataService.Pump();
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Pumping of CallData is executed"));
        }

        [Route("api/pump/CallTree")]
        public async void  PumpCallTree()
        {
            _callTreeService.Pump();

            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Pumping of CallTree is executed"));
        }

        [Route("api/pump/EmployeeHours")]
        public async void PumpEmployeeHours()
        {
            await _employeeHourService.Pump();
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Pumping of EmployeeHours is executed"));
        }
    }
}