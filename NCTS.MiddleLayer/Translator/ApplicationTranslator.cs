using NCTS.MiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.MiddleLayer.Translator
{
    public static class ApplicationTranslator
    {
        public static List<Application> ToModel(this List<ApplicationProxy> proxyModelList)
        {
            List<Application> applicationList = new List<Application>();
            foreach (var item in proxyModelList)
            {
                applicationList.Add(new Application()
                {
                    ApplicationName = item.name
                });
            }
            return applicationList;
        }
    }
}
