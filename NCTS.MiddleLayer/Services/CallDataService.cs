using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using Serilog;

namespace NCTS.MiddleLayer.Services
{
    public class CallDataService:ICallDataService
    {
        private IDatabaseService _dataService;
        private ICallDataProxyService _callDataProxyService;

        public CallDataService(IDatabaseService databaseService,ICallDataProxyService callDataProxyService)
        {
            _dataService = databaseService;
            _callDataProxyService = callDataProxyService;
        }

        public void Pump()
        {
            var callDataList = _callDataProxyService.GetProxyObjects().ToModel();
            _dataService.InsertCallData(callDataList);

            Log.Information("Call Data is successfully passed to the DBLayer");
            
        }
    }
}
