using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Services.TranslatorServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NCTS.Services.ApiProxyModelServices
{
    public class CallTreeServices : IApiModelServices<CallTreeProxy>
    {
        List<CallTreeProxy> callTreeProxyList = new List<CallTreeProxy>();
        private ApplicationServices _applicationServices;
        private ApplicationTranslator _applicationTranslator;
        private readonly string[] _environment = { "prod", "stage" };


        public CallTreeServices()
        {
            _applicationServices = new ApplicationServices();
            _applicationTranslator = new ApplicationTranslator();

        }

        public IEnumerable<CallTreeProxy> GetProxyObjects()
        {
            List<AppProxy> appProxiesModelList = _applicationServices.GetProxyObjects().ToList();
            var applicationList = _applicationTranslator.ToModel(appProxiesModelList);
            foreach (var environment in _environment)
            {
                foreach (var app in applicationList)
                {
                    string application = app.Name;
                    string callTreeApi = "https://chatops.common.cnxloyalty.com/api/calltree/" + application + "/" + environment;
                    //we call this method asynchronously in future
                    string callTreeString = GetCallTreeJsonString(callTreeApi);
                    List<CallTreeProxy> jsonCallProxy = JsonConvert.DeserializeObject<List<CallTreeProxy>>(callTreeString);
                    callTreeProxyList.Add(jsonCallProxy[0]);
                }
            }
            return callTreeProxyList;
        }
        private static string GetCallTreeJsonString(string callTreeApi)
        {
            string temp = new WebClient().DownloadString(callTreeApi);
            temp = "[" + temp + "]";
            return temp;
        }
    }
}
