using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Services.ApiProxyModelServices
{
    public class ApplicationServices : IApplicationServices
    {
        public List<AppProxy> ApplicationList;
        public List<AppProxy> GetProxyObjects()
        { 
            using (StreamReader r = new StreamReader(typeof(ApplicationServices).Assembly.GetManifestResourceStream("NCTS.Services.applications.json")))
            {
                string json = r.ReadToEnd();
                try
                {
                    ApplicationList = JsonConvert.DeserializeObject<List<AppProxy>>(json);
                }
                catch (Exception ex)
                {
                    Log.Information(ex.Message.ToString());                
                }
            }
            return ApplicationList;
        }
    
    }
}
