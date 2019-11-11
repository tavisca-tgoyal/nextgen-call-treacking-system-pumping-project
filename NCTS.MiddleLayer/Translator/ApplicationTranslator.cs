﻿using NCTS.DatabaseMiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System.Collections.Generic;

namespace NCTS.MiddleLayer.Translator
{
    public static class ApplicationTranslator
    {
        public static List<Application> ToModel(this List<ApplicationProxy> proxyModelList)
        {
            List<Application> applicationList = new List<Application>();
            foreach (var app in proxyModelList)
            {
                applicationList.Add(new Application()
                {
                    ApplicationName = app.name.ToLower()
                });
            }
            return applicationList;
        }
    }
}
