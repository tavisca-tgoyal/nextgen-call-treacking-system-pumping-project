using NCTS.Contracts.Interfaces.ApiProxyModel;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Services.TranslatorServices;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Services.ApiProxyModelServices
{
    public class CallTreeServices : ICallTreeServices
    {
        List<CallTreeProxy> callTreeProxyList = new List<CallTreeProxy>();
        private ApplicationServices _applicationServices;
        private readonly string[] _environment = { "prod", "stage" };


        public CallTreeServices()
        {
            _applicationServices = new ApplicationServices();

        }
        public async Task<List<CallTreeProxy>> GetProxyObjects()
        {
            await GetCallTreeAsync();
            return callTreeProxyList;
        }

        private async Task GetCallTreeAsync()
        {
            List<AppProxy> appProxiesModelList = _applicationServices.GetProxyObjects().ToList();
            var applicationList = ApplicationTranslator.ToModel(appProxiesModelList);

            //list that stores task objects and after they all finished work with them
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var environment in _environment)
            {
                foreach (var app in applicationList)
                {
                    string application = app.ApplicationName;
                    string callTreeApi = "https://chatops.common.cnxloyalty.com/api/calltree/" + application + "/" + environment;

                    tasks.Add(GetCallTreeJsonString(callTreeApi));
                    //string callTreeString = Task.Run(() => GetCallTreeJsonString(callTreeApi));                    
                }
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                try
                {
                    List<CallTreeProxy> jsonCallProxy = JsonConvert.DeserializeObject<List<CallTreeProxy>>(item);
                    callTreeProxyList.Add(jsonCallProxy[0]);
                }
                catch (Exception ex)
                {
                    Log.Information(ex.Message.ToString());
                }
            }
        }

        private async Task<string> GetCallTreeJsonString(string callTreeApi)
        {
            string temp = await new WebClient().DownloadStringTaskAsync(callTreeApi);
            temp = "[" + temp + "]";
            return temp;
        }

        
    }
}
