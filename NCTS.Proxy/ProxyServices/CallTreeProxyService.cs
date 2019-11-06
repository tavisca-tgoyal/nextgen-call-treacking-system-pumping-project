using NCTS.Proxy.Interfaces;
using NCTS.Proxy.ProxyClasses;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;

namespace NCTS.Proxy.ProxyServices
{
    public class CallTreeProxyService : ICallTreeProxyService
    {

        private readonly IConfigurationProvider _configurationProvider;
        public CallTreeProxyService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        List<CallTreeProxy> callTreeProxyList = new List<CallTreeProxy>();
        private IApplicationProxyService _applicationServices;
        private readonly string[] _environment = { "prod", "stage" };


        public CallTreeProxyService(IApplicationProxyService applicationProxyService)
        {
            _applicationServices = applicationProxyService;

        }

  

        public async Task<List<CallTreeProxy>> GetProxyObjects()
        {
            await GetCallTreeAsync();
            return callTreeProxyList;
        }

        private async Task GetCallTreeAsync()
        {
            List<ApplicationProxy> appProxiesModelList = _applicationServices.GetProxyObjects().ToList();

            //list that stores task objects and after they all finished work with them
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var environment in _environment)
            {
                foreach (var app in appProxiesModelList)
                {
                    string application = app.name;
                    var apiUrl = await _configurationProvider.GetGlobalConfigurationAsStringAsync("raw_data_url", "call_tree_api");
                    string callTreeApi = apiUrl + application + "/" + environment;

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
