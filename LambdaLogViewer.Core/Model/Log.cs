using System.Text.Json.Serialization;

namespace LambdaLogViewer.Core.Model
{
    public class Log
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public long Timestamp { get; set; }

        [JsonPropertyName("log_level")]
        public string LogLevel { get; set; }

        public LogException Exception { get; set; }
    }

    public class LogException
    {
        public string Type { get; set; }

        public string Message { get; set; }
    }
}
