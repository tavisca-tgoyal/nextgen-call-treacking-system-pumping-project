using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Services
{
    public class CallTreeService : ICallTreeService
    {
        private IDatabaseService _dataService;
        private ICallTreeProxyService _callTreeProxyService;

        public CallTreeService(IDatabaseService databaseService, ICallTreeProxyService callTreeProxyService)
        {
            _dataService = databaseService;
            _callTreeProxyService = callTreeProxyService;
        }
        public async Task Pump()
        {
            var callTreeProxies = await _callTreeProxyService.GetProxyObjects();
            var callTreeList = callTreeProxies.ToModel();
            _dataService.InsertCallTrees(callTreeList);

            Log.Information("CallTree Data is successfully passed to the DBLayer");
        }
    }
}
