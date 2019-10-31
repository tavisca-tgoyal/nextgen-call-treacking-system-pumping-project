using NCTS.MiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.MiddleLayer.Translator
{
    public static class CallTreeTranslator
    {
        public static List<CallTree> ToModel(this List<CallTreeProxy> proxyModelList)
        {
            List<CallTree> callTreeList = new List<CallTree>();
            foreach (var proxyModel in proxyModelList)
            {
                if (proxyModel.Level1 != 0)
                {
                    callTreeList.Add(new CallTree()
                    {
                        ApplicationName = proxyModel.Application,
                        Environment = proxyModel.Environment,
                        Level1Employee = proxyModel.Level1,
                        Level2Employee = proxyModel.Level2,
                        Level3Employee = proxyModel.Level3
                    });
                }
            }
            return callTreeList;
        }
    }
}
