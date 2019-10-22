using NCTS.Contracts.Interfaces.Translator;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{
    public class CallDataTranslator : ITranslator<CallData, CallDataProxy>
    {
        public List<CallData> ToModel(List<CallDataProxy> proxyModelList)
        {
            var callData = new List<CallData>();
            foreach (var call in proxyModelList[0].responses[0].hits.hits)
            {
                callData.Add(new CallData()
                {
                    application = call._source.application,
                    environment = call._source.environment,
                    call_action = call._source.call_action,
                    employee_id = call._source.employee_id,
                    alarm_name = call._source.alarm_name,
                    datetime = call._source.time_stamp;
                });
            }
            return callData;
        }

    }
}
