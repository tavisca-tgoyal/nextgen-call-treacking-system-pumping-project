using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;

namespace Common.Logging
{
    public class ServiceLogger : ILogger
    {
        public async Task WriteLogAsync(ILog log) => await Logger.WriteLogAsync(log);

        public async Task LogExceptionAsync(ILog log) => await Logger.WriteLogAsync(log);
    }
}
