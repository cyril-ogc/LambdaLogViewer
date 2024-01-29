using LambdaLogViewer.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace LambdaLogViewer.Core.Filter
{
    public class LogFilter : ILogFilter
    {
        private const string LOG_LEVEL_ERROR = "ERROR";
        private const string LOG_LEVEL_WARNING = "WARN";

        public IEnumerable<Log> GetAllErrors(IEnumerable<Log> from) => from.Where(log => log.LogLevel == LOG_LEVEL_ERROR || log.LogLevel == LOG_LEVEL_WARNING);
    }
}
