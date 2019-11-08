using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.ConfigurationHandler;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.Plugins.Json;

namespace Common.Logging
{
    public class LogWriterFactory : ILogWriterFactory
    {
        private ILogSink logSink;
        public IApplicationLogWriter CreateWriter()
        {

            logSink = ServiceLocator.Current.GetInstance<ILogSink>();
            return new LogWriter(JsonLogFormatter.Instance, logSink);
        }
    }
}
