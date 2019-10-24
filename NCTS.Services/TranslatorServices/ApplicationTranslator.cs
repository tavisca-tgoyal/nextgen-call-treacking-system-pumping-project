using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{

    public static class ApplicationTranslator
    {
        public static List<Application> ToModel(this List<AppProxy> proxyModelList)
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
