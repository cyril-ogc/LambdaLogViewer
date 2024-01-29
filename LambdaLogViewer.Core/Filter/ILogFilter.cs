namespace LambdaLogViewer.Core.Filter
{
    using LambdaLogViewer.Core.Model;
    using System.Collections.Generic;

    public interface ILogFilter
    {
        IEnumerable<Log> GetAllErrors(IEnumerable<Log> from);
    }
}