using Common.Logging;
using NCTS.DatabaseMiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System;
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
                    ApplicationName = call._source.application.Format(),
                    Environment = call._source.environment,
                    CallAction = call._source.call_action,
                    EmployeeCode = call._source.employee_id,
                    AlarmName = call._source.alarm_name,
                    TimeStamp = call._source.time_stamp
                });
            }
            return callData;
        }

        private static string Format(this string application)
        {
            string[] splittedAppName = new string[] { };
            string formattedAppName = string.Empty;

            if (application.Contains('_'))
            {
                splittedAppName = application.Split('_');
            }
            else if (application.Contains('-'))
            {
                splittedAppName = application.Split('-');
            }
            else
            {
                try
                {
                    formattedAppName = application.ToLower();
                }
                catch (Exception e)
                {
                    ILogger logger = new ServiceLogger();
                    logger.WriteLogAsync(LogHelper.GetTraceLog("Application Name doesn't formatted correctly and exception is:" + e.Message.ToString() + "application name that we're are trying to format is" + application));
                    return application;
                }
            }

            foreach(string str in splittedAppName)
            {
                formattedAppName += str.ToLower() + " ";
            }
            return formattedAppName.Trim();
        }
    }
}
