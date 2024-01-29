namespace LambdaLogViewer.SPA.Services
{
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogViewerService
    {
        IEnumerable<Log> GetLogs(string inputString);
        Task<IEnumerable<Log>> GetLogsAsync(string inputString);
    }
}
