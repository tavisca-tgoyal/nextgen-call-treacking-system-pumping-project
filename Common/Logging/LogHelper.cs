using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Logging;

namespace Common.Logging
{
    public static class LogHelper
    {
        public static TraceLog GetTraceLog(string message)
        {
            var apiLog = new TraceLog()
            {
                ApplicationName="call_tracking_system",
                Category="pump",
                Message = message,
                LogTime = DateTime.Today
            };
            return apiLog;
        }
        public static ExceptionLog GetExceptionLog(Exception exception)
        {
            var exceptionLog = new ExceptionLog()
            {
                ApplicationName = "call_tracking_system",
                Message = exception.Message,
                LogTime = DateTime.Today,
                ExceptionType=exception.GetType().ToString()
            };
            return exceptionLog;
        }

    }
}
