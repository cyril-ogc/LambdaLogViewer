namespace LambdaLogViewer.SPA.Services
{
    using LambdaLogViewer.Core.Cleaner;
    using LambdaLogViewer.Core.Converter;
    using LambdaLogViewer.Core.Filter;
    using LambdaLogViewer.Core.Formatter;
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LogViewerService : ILogViewerService
    {
        private readonly IJsonCleaner _jsonCleaner;
        private readonly ILogConverter _jsonConverter;
        private readonly ILogFilter _logFilter;
        private readonly IExceptionMessageFormatter _exceptionMessageFormatter;

        public LogViewerService(IJsonCleaner jsonCleaner, 
            ILogConverter jsonConverter, 
            ILogFilter logFilter, 
            IExceptionMessageFormatter exceptionMessageFormatter)
        {
            _jsonCleaner = jsonCleaner;
            _jsonConverter = jsonConverter;
            _logFilter = logFilter;
            _exceptionMessageFormatter = exceptionMessageFormatter;
        }

        public IEnumerable<Log> GetLogs(string inputString)
        {
            var cleanedJson = _jsonCleaner.Clean(inputString);
            var convertedJson = _jsonConverter.Convert(cleanedJson);
            var logs = _logFilter.GetAllErrors(convertedJson);

            if (logs == null) return Enumerable.Empty<Log>();

            foreach (var log in logs) 
                if (log?.Exception != null)
                    log.Exception.Message = _exceptionMessageFormatter.Format(log.Exception.Message);

            return logs.OrderBy(log => log.Timestamp).ToList();
        }

        public Task<IEnumerable<Log>> GetLogsAsync(string inputString)
        {
            throw new System.NotImplementedException();
        }
    }
}
