using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using NCTS.Contracts.Interfaces.Translator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{

    public class ApplicationTranslator : ITranslator<Application, AppProxy>
    {
        public List<Application> ToModel(List<AppProxy> proxyModelList)
        {
            List<Application> applicationList = new List<Application>();
            foreach (var item in proxyModelList[0].Property1)
            {
                applicationList.Add(new Application()
                {
                    Name = item.name
                });
            }
            return applicationList;
        }
    }
}
