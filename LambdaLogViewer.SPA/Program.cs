using LambdaLogViewer.Core.Cleaner;
using LambdaLogViewer.Core.Converter;
using LambdaLogViewer.Core.Filter;
using LambdaLogViewer.Core.Formatter;
using LambdaLogViewer.SPA.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LambdaLogViewer.SPA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            BindLogCoreInterfaces(builder.Services);

            builder.Services.AddScoped<ILogViewerService, LogViewerService>();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            await builder.Build().RunAsync();
        }

        #region Private method(s)

        private static void BindLogCoreInterfaces(IServiceCollection services)
        {
            services.AddSingleton<IJsonCleaner, JsonCleaner>();
            services.AddSingleton<ILogConverter, LogConverter>();
            services.AddSingleton<ILogFilter, LogFilter>();
            services.AddSingleton<IExceptionMessageFormatter, HtmlExceptionMessageFormatter>();
        }

        #endregion
    }
}
