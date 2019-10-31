using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyClasses;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Proxy.ProxyServices
{
    public class EmployeeProxyService : IEmployeProxyService
    {
        private List<EmployeeProxy> _employeeList;
        public async Task<List<EmployeeProxy>> GetProxyObjects()
        {
            try
            {
                string EmpJsonString = await new WebClient().DownloadStringTaskAsync("https://chatops.common.cnxloyalty.com/api/team");
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
