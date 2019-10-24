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
        private IEmployeeServices _employeeServices;
        private IApplicationServices _applicationServices;
        private ICallDataServices _callDataServices;
        private ICallTreeServices _callTreeServices;

        public PumpController(IDatabaseServices DatabaseService, IEmployeeServices EmployeeServices, IApplicationServices ApplicationServices, ICallDataServices CallDataServices, ICallTreeServices CallTreeServices)
        {
            _databaseServices = DatabaseService;
            _employeeServices = EmployeeServices;
            _applicationServices = ApplicationServices;
            _callDataServices = CallDataServices;
            _callTreeServices = CallTreeServices;
        }

        [Route("api/pump/employee")]
        public async Task PumpEmployees()
        {
            List<EmployeeProxy> employeeProxies = await _employeeServices.GetProxyObjects();
            _databaseServices.InsertEmployees(employeeProxies.ToModel());

            Log.Information("Employee Data is passed to Database Layer Successfully");
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            List<AppProxy> appProxies = _applicationServices.GetProxyObjects();
            _databaseServices.InsertApplications(appProxies.ToModel());

            Log.Information("Application data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            List<CallDataProxy> callDataProxies = _callDataServices.GetProxyObjects();
            _databaseServices.InsertCallData(callDataProxies.ToModel());

            Log.Information("Call data is Passed to Database Layer Successfully");
        }

        [Route("api/pump/CallTree")]
        public async Task PumpCallTree()
        {
            List<CallTreeProxy> callTreeProxies = await _callTreeServices.GetProxyObjects();
            _databaseServices.InsertCallTrees(callTreeProxies.ToModel());

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