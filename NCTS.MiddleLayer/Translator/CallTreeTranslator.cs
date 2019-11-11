using NCTS.DatabaseMiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System.Collections.Generic;

namespace NCTS.MiddleLayer.Translator
{
    public static class CallTreeTranslator
    {
        public static List<CallTree> ToModel(this List<CallTreeProxy> callTreeProxyModelList)
        {
            List<CallTree> callTreeList = new List<CallTree>();
            foreach (var callTreeProxyModel in callTreeProxyModelList)
            {
                if (callTreeProxyModel.Level1 != 0 || callTreeProxyModel.Level2 != 0 || callTreeProxyModel.Level3 != 0)
                {
                    callTreeList.Add(new CallTree()
                    {
                        ApplicationName = callTreeProxyModel.Application.ToLower(),
                        Environment = callTreeProxyModel.Environment,
                        Level1Employee = callTreeProxyModel.Level1,
                        Level2Employee = callTreeProxyModel.Level2,
                        Level3Employee = callTreeProxyModel.Level3
                    });
                }
            }
            return callTreeList;
        }
    }
}
