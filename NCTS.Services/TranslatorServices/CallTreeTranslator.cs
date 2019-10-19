using NCTS.Contracts.Interfaces.Translator;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{
    public class CallTreeTranslator : ITranslator<CallTree, CallTreeProxy>
    {
        public List<CallTree> ToModel(List<CallTreeProxy> proxyModelList)
        {
            List<CallTree> callTreeList = new List<CallTree>();
            foreach (var proxyModel in proxyModelList)
            {
                callTreeList.Add(new CallTree()
                {
                    Application = proxyModel.Application,
                    Environment = proxyModel.Environment,
                    Level1 = proxyModel.Level1,
                    Level2 = proxyModel.Level2,
                    Level3 = proxyModel.Level3
                });
            }
            return callTreeList;
        }
    }
}
