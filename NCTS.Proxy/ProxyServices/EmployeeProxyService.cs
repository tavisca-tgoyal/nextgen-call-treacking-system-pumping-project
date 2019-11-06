using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyClasses;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;

namespace NCTS.Proxy.ProxyServices
{
    public class EmployeeProxyService : IEmployeeProxyService
    {

        private readonly IConfigurationProvider _configurationProvider;
        public EmployeeProxyService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

    

        private List<EmployeeProxy> _employeeList;
        public async Task<List<EmployeeProxy>> GetProxyObjects()
        {
            try
            {
                var apiUrl = await _configurationProvider.GetGlobalConfigurationAsStringAsync("raw_data_url", "employee_api");
                string EmpJsonString = await new WebClient().DownloadStringTaskAsync(apiUrl);
                _employeeList = JsonConvert.DeserializeObject<List<EmployeeProxy>>(EmpJsonString);
            }
            catch (Exception ex)
            {

                Log.Information(ex.Message.ToString());
            }

            return _employeeList;
        }


    }
}
