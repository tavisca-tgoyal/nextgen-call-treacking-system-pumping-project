using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Services.ApiProxyModelServices
{
    public class EmployeeServices : IEmployeeServices
    {
        List<EmployeeProxy> EmployeeList; 
        public async Task<List<EmployeeProxy>> GetProxyObjects()
        {
            string EmpJsonString = await new WebClient().DownloadStringTaskAsync("https://chatops.common.cnxloyalty.com/api/team");
            EmployeeList = JsonConvert.DeserializeObject<List<EmployeeProxy>>(EmpJsonString);
            return EmployeeList;
        }
    }
}
