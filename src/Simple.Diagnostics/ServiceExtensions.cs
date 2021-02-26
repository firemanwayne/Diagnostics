using Microsoft.Extensions.Logging;
using Simple.Diagnostics;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTCPDiagnostics(this IServiceCollection services)
        {
            services.AddSingleton<ITcpMonitor>(sp =>
            {
                var logger = sp.GetRequiredService<ILoggerProvider>();

                var Monitor = new TcpMonitor();

                Monitor
                .Start(logger.CreateLogger("error"), TimeSpan.FromSeconds(10))
                .ConfigureAwait(false);

                return Monitor;
            });

            return services;
        }
    }
}
