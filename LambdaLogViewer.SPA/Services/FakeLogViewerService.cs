namespace LambdaLogViewer.SPA.Services
{
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FakeLogViewerService : ILogViewerService
    {
        public IEnumerable<Log> GetLogs(string inputString)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(string inputString)
        {
            return await Task.Run(() => GetLogs());
        }

        private IEnumerable<Log> GetLogs()
        {
            return new List<Log> { new Log { Timestamp = 123456, LogLevel = "ERROR", Message = "Foo message" } };
        }
    }
}
