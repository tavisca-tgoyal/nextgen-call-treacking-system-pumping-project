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

        public ApplicationService(IApplicationProxyService applicationProxyService, IDatabaseService databaseService)
        {
            _applicationProxyService = applicationProxyService;
            _databaseService = databaseService;
        }
        public void Pump()
        {
            var applicationList = _applicationProxyService.GetProxyObjects().ToModel();
            _databaseService.InsertApplications(applicationList);
        }
    }
}
