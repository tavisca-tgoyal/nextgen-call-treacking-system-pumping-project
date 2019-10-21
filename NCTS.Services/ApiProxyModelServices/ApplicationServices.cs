using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NCTS.Services.ApiProxyModelServices
{
    public class ApplicationServices : IApiModelServices<AppProxy>
    {
        public List<AppProxy> ApplicationList;
        public IEnumerable<AppProxy> GetProxyObjects()
        {            
         string path = @"..\NCTS.Services\applications.json";

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                ApplicationList = JsonConvert.DeserializeObject<List<AppProxy>>(json);
            }
            return ApplicationList;
        }
    
    }
}
