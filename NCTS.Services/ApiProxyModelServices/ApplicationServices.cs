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
    public class ApplicationServices : IApplicationServices
    {
        public List<AppProxy> ApplicationList;
        public IEnumerable<AppProxy> GetProxyObjects()
        { 
            using (StreamReader r = new StreamReader(typeof(ApplicationServices).Assembly.GetManifestResourceStream("NCTS.Services.applications.json")))
            {
                string json = r.ReadToEnd();
                ApplicationList = JsonConvert.DeserializeObject<List<AppProxy>>(json);
            }
            return ApplicationList;
        }
    
    }
}
