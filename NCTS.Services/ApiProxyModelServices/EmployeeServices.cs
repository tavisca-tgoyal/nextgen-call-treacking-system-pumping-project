using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;

namespace NCTS.Services.ApiProxyModelServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IConfigurationProvider _configurationProvider;
        public EmployeeServices(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        List<EmployeeProxy> EmployeeList; 
        public async Task<List<EmployeeProxy>> GetProxyObjects()
        {
            try
            {
                var value = _configurationProvider.GetGlobalConfigurationAsStringAsync("rewards_settings", "rules_engine_url");
                string EmpJsonString = await new WebClient().DownloadStringTaskAsync("https://chatops.common.cnxloyalty.com/api/team");
                EmployeeList = JsonConvert.DeserializeObject<List<EmployeeProxy>>(EmpJsonString);
            }
            catch (Exception ex)
            {

                Log.Information(ex.Message.ToString());
            }
            
            return EmployeeList;
        }
    }
}
