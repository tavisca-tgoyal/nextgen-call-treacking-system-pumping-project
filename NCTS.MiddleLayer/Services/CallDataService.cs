using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;

namespace NCTS.MiddleLayer.Services
{
    public class CallDataService:ICallDataService
    {
        private IDatabaseService _dataService;
        private ICallDataProxyService _callDataProxyService;
        private ILogger _logger;

        public CallDataService(IDatabaseService databaseService,ICallDataProxyService callDataProxyService,ILogger logger)
        {
            _dataService = databaseService;
            _callDataProxyService = callDataProxyService;
            _logger = logger;
        }

        public async void Pump()
        {
            var callDataList = await _callDataProxyService.GetProxyObjects();
            var callList = callDataList.ToModel();
            _dataService.InsertCallData(callList);
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Call Data is successfully passed to the Database"));
            
        }
    }
}
