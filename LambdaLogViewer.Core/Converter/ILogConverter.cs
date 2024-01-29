namespace LambdaLogViewer.Core.Converter
{
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogConverter
    {
        IEnumerable<Log> Convert(string inputJson);
    }
}
