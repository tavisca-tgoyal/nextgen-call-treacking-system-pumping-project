using System.Threading.Tasks;
using Tavisca.Platform.Common.Logging;

namespace Common.Logging
{
    public interface ILogger
    {
        Task WriteLogAsync(ILog log);

        Task LogExceptionAsync(ILog log);
    }
}
