using NCTS.DatabaseMiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System.Collections.Generic;

namespace NCTS.MiddleLayer.Translator
{
    public static class CallDataTranslator
    {
        public static List<CallData> ToModel(this List<CallDataProxy> proxyModelList)
        {
            var callData = new List<CallData>();
            foreach (var call in proxyModelList[0].responses[0].hits.hits)
            {
                callData.Add(new CallData()
                {
                    ApplicationName = call._source.application,
                    Environment = call._source.environment,
                    CallAction = call._source.call_action,
                    EmployeeCode = call._source.employee_id,
                    AlarmName = call._source.alarm_name,
                    TimeStamp = call._source.time_stamp
                });
            }
            return callData;
        }
    }
}
