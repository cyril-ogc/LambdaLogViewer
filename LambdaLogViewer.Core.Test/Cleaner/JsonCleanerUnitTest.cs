namespace LambdaLogViewer.Core.Test.Cleaner
{
    using LambdaLogViewer.Core.Cleaner;
    using Xunit;

    public class JsonCleanerUnitTest
    {
        [Fact]
        public void Clean_Should_Return_CleanedJson()
        {
            string json = @"{""id"": 1, ""category"": ""categ1"" }{""id"": 1, ""category"": ""categ1"" }";

            IJsonCleaner jsonCleaner = new JsonCleaner();
            string cleanedJson = jsonCleaner.Clean(json);

            Assert.Equal(@"[{""id"": 1, ""category"": ""categ1"" },{""id"": 1, ""category"": ""categ1"" }]", cleanedJson);
;       }
    }
}
