using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCTS.Contracts;
using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Interfaces.Translator;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using NCTS.DatabaseServices;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using NCTS.Services.Utility;

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
            IApiModelServices<EmployeeProxy> apiModelServices = new EmployeeServices();
            ITranslator<Employee,EmployeeProxy> translator = new EmployeeTranslator();

            List<EmployeeProxy> employeeProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertEmployees(translator.ToModel(employeeProxies));
        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {
            IApiModelServices<AppProxy> apiModelServices = new ApplicationServices();
            ITranslator<Application, AppProxy> translator = new ApplicationTranslator();

            List<AppProxy> appProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertApplications(translator.ToModel(appProxies));
        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {
            IApiModelServices<CallDataProxy> apiModelServices = new CallDataServices();
            ITranslator<CallData, CallDataProxy> translator = new CallDataTranslator();

            List<CallDataProxy> callDataProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertCallData(translator.ToModel(callDataProxies));
        }

        [Route("api/pump/CallTree")]
        public void PumpCallTree()
        {
            IApiModelServices<CallTreeProxy> apiModelServices = new CallTreeServices();
            ITranslator<CallTree, CallTreeProxy> translator = new CallTreeTranslator();

            List<CallTreeProxy> callTreeProxies = apiModelServices.GetProxyObjects().ToList();
            _databaseServices.InsertCallTrees(translator.ToModel(callTreeProxies));
        }

        [Route("api/pump/EmployeeHours")]
        public void PumpEmployeeHours()
        {
            EmployeeHour employeeHourList = new EmployeeHour();
            _databaseServices.InsertEmployeeHours(employeeHourList.GetEmployeeHours());
        }
    }
}