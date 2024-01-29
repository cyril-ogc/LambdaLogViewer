namespace LambdaLogViewer.Core.Converter
{
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class LogConverter : ILogConverter
    {
        public IEnumerable<Log> Convert(string inputJson) => 
            JsonSerializer.Deserialize<IEnumerable<Log>>(inputJson, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
    }
}
