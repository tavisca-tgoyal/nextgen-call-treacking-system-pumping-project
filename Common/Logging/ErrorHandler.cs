using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.ExceptionManagement;

namespace Common.Logging
{
    public class ErrorHandler : IErrorHandler
    {
        private ILogger _logger;
        public ErrorHandler(ILogger logger)
        {
            _logger = logger;
        }

        public bool HandleException(Exception ex, string policy, out Exception newException)
        {
            _logger.LogExceptionAsync(LogHelper.GetExceptionLog(ex));
            newException = null;
            return false;
        }
    }
}
