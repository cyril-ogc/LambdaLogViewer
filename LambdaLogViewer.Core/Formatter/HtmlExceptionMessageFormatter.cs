namespace LambdaLogViewer.Core.Formatter
{
    public class HtmlExceptionMessageFormatter : IExceptionMessageFormatter
    {
        public string Format(string exceptionMessage) =>
            ChekAndAddBrTagForCarriageReturn(
                CheckAndAddTabulationForAt(
                    CheckAndAddTabulationsForIn(exceptionMessage)
                )
            );

        #region Private method(s)

        private string ChekAndAddBrTagForCarriageReturn(string exceptionMessage) => exceptionMessage?.Replace("\n", $"<br>");

        private string CheckAndAddTabulationForAt(string exceptionMessage) => exceptionMessage?.Replace("at ", "&emsp;at ");

        private string CheckAndAddTabulationsForIn(string exceptionMessage) => exceptionMessage?.Replace("in ", "&emsp;&emsp;in ");

        #endregion
    }
}
