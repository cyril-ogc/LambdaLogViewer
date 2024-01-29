namespace LambdaLogViewer.Core.Cleaner
{
    public class JsonCleaner : IJsonCleaner
    {
        public string Clean(string inputJson) => CheckAndAddBrackets(CheckAndAddCommas(inputJson));

        #region Private method(s)
        private string CheckAndAddBrackets(string inputJson)
        {
            if (IsStartingBracketMissing(inputJson)) inputJson = AddStartingBracket(inputJson);
            if (IsEndingBracketMissing(inputJson)) inputJson = AddEndingBracket(inputJson);

            return inputJson;
        }

        private string CheckAndAddCommas(string inputJson) => inputJson?.Replace("}{", "},{")?.Replace("}\n{", "},{");

        private string AddEndingBracket(string inputJson) => $"{inputJson}]";

        private bool IsEndingBracketMissing(string inputJson) => !inputJson.EndsWith("]");

        private string AddStartingBracket(string inputJson) => $"[{inputJson}";

        private bool IsStartingBracketMissing(string inputJson) => !inputJson.StartsWith("[");

        #endregion
    }
}
