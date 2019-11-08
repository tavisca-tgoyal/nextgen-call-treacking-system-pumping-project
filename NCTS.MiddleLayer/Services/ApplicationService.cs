using Common.Logging;
using NCTS.DatabaseMiddleLayer;
using NCTS.MiddleLayer.Interfaces;
using NCTS.MiddleLayer.Translator;
using NCTS.Proxy.Interfaces;

namespace NCTS.MiddleLayer.Services
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationProxyService _applicationProxyService;
        private IDatabaseService _databaseService;
        private ILogger _logger;

        public ApplicationService(IApplicationProxyService applicationProxyService, IDatabaseService databaseService,ILogger logger)
        {
            _applicationProxyService = applicationProxyService;
            _databaseService = databaseService;
            _logger = logger;
        }
        public async void Pump()
        {
            var applicationList = _applicationProxyService.GetProxyObjects().ToModel();
            _databaseService.InsertApplications(applicationList);
            await _logger.WriteLogAsync(LogHelper.GetTraceLog("Application list is successfully passed to the DBLayer"));

        }
    }
}
