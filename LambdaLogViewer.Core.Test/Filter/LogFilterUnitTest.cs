namespace LambdaLogViewer.Core.Test.Filter
{
    using LambdaLogViewer.Core.Filter;
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class LogFilterUnitTest
    {
        [Fact]
        public void GetAllErrors_Should_Return_ErrorLogs()
        {
            List<Log> logs = new List<Log>
            {
                new Log { Type = "logs", LogLevel = "INFO", Message = "message info" },
                new Log { Type = "logs", LogLevel = "ERROR", Message = "message error" }
            };

            ILogFilter logFilter = new LogFilter();
            var filteredLogs = logFilter.GetAllErrors(logs);

            Assert.NotNull(filteredLogs);
            Assert.NotEmpty(filteredLogs);
            Assert.Single(filteredLogs);

            var firstLog = filteredLogs.First();

            Assert.Equal("logs", firstLog.Type);
            Assert.Equal("ERROR", firstLog.LogLevel);
            Assert.Equal("message error", firstLog.Message);
        }
    }
}
