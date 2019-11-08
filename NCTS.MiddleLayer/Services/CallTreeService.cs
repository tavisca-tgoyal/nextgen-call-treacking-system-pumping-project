using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;

namespace NCTS.MiddleLayer.Services
{
    public class CallTreeService : ICallTreeService
    {
        private IDatabaseService _dataService;
        private ICallTreeProxyService _callTreeProxyService;
        private ILogger _logger;

        public CallTreeService(IDatabaseService databaseService, ICallTreeProxyService callTreeProxyService,ILogger logger)
        {
            _dataService = databaseService;
            _callTreeProxyService = callTreeProxyService;
            _logger = logger;
        }
        public async void Pump()
        {
            var callTreeProxies = await _callTreeProxyService.GetProxyObjects();
            var callTreeList = callTreeProxies.ToModel();
            _dataService.InsertCallTrees(callTreeList);
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("CallTree Data is successfully passed to the Database"));
        }
    }
}
