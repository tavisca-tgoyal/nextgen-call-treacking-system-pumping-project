using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCTS.Contracts;
using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using NCTS.DatabaseServices;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using NCTS.Services.Utility;
using Serilog;

namespace NCTS.WebApi.Controllers
{
    
    [ApiController]
    public class PumpController : ControllerBase
    {
        private IDatabaseServices _databaseServices;
        public PumpController(IDatabaseServices DatabaseService)
        {
            _databaseServices = DatabaseService;
        }

        [Route("api/pump/employee")]
        public void PumpEmployees()
        {
            IEmployeeServices apiModelServices = new EmployeeServices();
            List<EmployeeProxy> employeeProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertEmployees(EmployeeTranslator.ToModel(employeeProxies));

            Log.Information("Employee Data is passed to Database Layer Successfully");
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            IApplicationServices apiModelServices = new ApplicationServices();

            List<AppProxy> appProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertApplications(ApplicationTranslator.ToModel(appProxies));

            Log.Information("Application data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            ICallDataServices apiModelServices = new CallDataServices();

            List<CallDataProxy> callDataProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertCallData(CallDataTranslator.ToModel(callDataProxies));

            Log.Information("Call data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallTree")]
        public async Task<ActionResult> PumpCallTree()
        {
            ICallTreeServices apiModelServices = new CallTreeServices();

            List<CallTreeProxy> callTreeProxies = await apiModelServices.GetProxyObjects();
            return Ok(callTreeProxies);
            //_databaseServices.InsertCallTrees(CallTreeTranslator.ToModel(callTreeProxies));

            Log.Information("CallTree data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/EmployeeHours")]
        public async Task PumpEmployeeHours()
        {
            EmployeeHour employeeHourList = new EmployeeHour();
            _databaseServices.InsertEmployeeHours(await employeeHourList.GetEmployeeHours());

            Log.Information("EmployeeHour data is Passed to Database Layer Successfully");
        }
    }
}