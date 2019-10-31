using NCTS.Proxy.Interfaces;
using System;
using Serilog;
using System.Collections.Generic;
using System.Text;
using NCTS.Proxy.ProxyClasses;
using System.IO;
using Newtonsoft.Json;

namespace NCTS.Proxy.ProxyServices
{
    public class ApplicationProxyService : IApplicationProxyService
    {
        private List<ApplicationProxy> _applicationList;
        public List<ApplicationProxy> GetProxyObjects()
        {
            using (StreamReader r = new StreamReader(typeof(ApplicationProxyService).Assembly.GetManifestResourceStream("NCTS.Proxy.application.json")))
            {
                string json = r.ReadToEnd();
                try
                {
                    _applicationList = JsonConvert.DeserializeObject<List<ApplicationProxy>>(json);
                }
                catch (Exception ex)
                {
                    Log.Information(ex.Message.ToString());
                }
            }
            return _applicationList;
        }
    }
}
