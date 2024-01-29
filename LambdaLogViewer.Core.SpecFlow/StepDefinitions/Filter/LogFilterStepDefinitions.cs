namespace LambdaLogViewer.Core.SpecFlow.StepDefinitions.Filter
{
    using LambdaLogViewer.Core.Filter;
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    
    [Binding]
    public sealed class LogFilterStepDefinitions
    {
        private List<Log> _logs;
        private List<Log> _filteredLogs;

        [Given("A INFO line and a ERROR line logs")]
        public void GivenInfoAndErrorLines()
        {
            _logs = new List<Log>
            {
                new Log { Type = "logs", LogLevel = "INFO", Message = "message info" },
                new Log { Type = "logs", LogLevel = "ERROR", Message = "message error" }
            };
        }

        [When("Filter is applied")]
        public void WhenFilterApplied()
        {
            LogFilter logFilter = new();

            _filteredLogs = logFilter.GetAllErrors(_logs).ToList();
        }

        [Then("Get a ERROR line")]
        public void ThenGetErrorLine()
        {
            var firstLog = _filteredLogs.First();

            Assert.Equal("logs", firstLog.Type);
            Assert.Equal("ERROR", firstLog.LogLevel);
            Assert.Equal("message error", firstLog.Message);
        }
    }
}
