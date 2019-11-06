using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyServices;
using Serilog;
using System.Linq;

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

        public async void Pump()
        {
            var callDataList = await _callDataProxyService.GetProxyObjects();
            var callList = callDataList.ToModel();
            _dataService.InsertCallData(callList);

            Log.Information("Call Data is successfully passed to the DBLayer");
            
        }
    }
}
