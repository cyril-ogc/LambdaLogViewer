namespace LambdaLogViewer.Core.Test.Converter
{
    using LambdaLogViewer.Core.Converter;
    using System.Linq;
    using Xunit;

    public class LogConverterUnitTest
    {
        [Fact]
        public void Convert_Should_Return_LogList()
        {
            string jsonToParse = @"[{""type"":""logs"",""timestamp"":1629725446179,""message"":""Sending HTTP request GET \""http://casino-game-stg2.betclic.net/api/v1/studios/44?game_limit=100&game_offset=0&embed=games&channelid=3&country=FR&regulatorId=2\"""",""class_method_name"":""System.Net.Http.HttpClient.casino-game.ClientHandler"",""hostname"":""703b460b3095"",""log_level"":""INFO"",""service"":{ ""name"":""poker.bonus.service"",""version"":""1.0.0""},""correlation_id"":""0HMB678R8P9KJ:00000001"",""http"":{ ""request"":{ ""client_ip"":""::ffff:172.17.0.1"",""url"":""GET /api/v1/freetickets"",""url_referrer"":""""},""headers"":""{\""Connection\"":\""keep-alive\"",\""Accept\"":\""*/*\"",\""Accept-Encoding\"":\""gzip, deflate, br\"",\""Host\"":\""localhost:8080\"",\""User-Agent\"":\""PostmanRuntime/7.28.3\"",\""X-BG-User\"":\""16395026\"",\""Postman-Token\"":\""4eb83202-0724-4b1f-a36e-718951c01591\""}"",""cookies"":""""}},{""type"":""logs"",""timestamp"":1629725446308,""message"":""An unhandled exception has occurred while executing the request."",""class_method_name"":""Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware"",""hostname"":""703b460b3095"",""log_level"":""ERROR"",""service"":{""name"":""poker.bonus.service"",""version"":""1.0.0""},""correlation_id"":""0HMB678R8P9KJ:00000001"",""exception"":{""message"":""System.Net.Http.HttpRequestException: Name or service not known\n \n"",""type"":""System.Net.Http.HttpRequestException""},""inner_exception"":{""message"":""System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known\n at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)"",""type"":""System.Net.Sockets.SocketException""},""http"":{""request"":{""client_ip"":""::ffff:172.17.0.1"",""url"":""GET /api/v1/freetickets"",""url_referrer"":""""},""headers"":""{\""Connection\"":\""keep-alive\"",\""Accept\"":\""*/*\"",\""Accept-Encoding\"":\""gzip, deflate, br\"",\""Host\"":\""localhost:8080\"",\""User-Agent\"":\""PostmanRuntime/7.28.3\"",\""X-BG-User\"":\""16395026\"",\""Postman-Token\"":\""4eb83202-0724-4b1f-a36e-718951c01591\""}"",""cookies"":""""}}]";

            ILogConverter logConverter = new LogConverter();
            var logs = logConverter.Convert(jsonToParse);

            Assert.NotNull(logs);
            Assert.NotEmpty(logs);
            
            var firstLog = logs.First();

            Assert.Equal("logs", firstLog.Type);
            Assert.Equal("INFO", firstLog.LogLevel);

            var lastLog = logs.Last();

            Assert.Equal("logs", lastLog.Type);
            Assert.Equal("ERROR", lastLog.LogLevel);
            Assert.StartsWith("System.Net.Http.HttpRequestException: Name or service not known", lastLog.Exception?.Message);
        }
    }
}
