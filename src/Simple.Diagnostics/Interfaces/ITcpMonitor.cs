using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Diagnostics
{
    internal interface ITcpMonitor
    {
        int ActiveConnections { get; }
        int InActiveConnections { get; }
        DateTimeOffset LastUpdated { get; }

        Task Start(ILogger Logger, TimeSpan Interval);
        IEnumerable<TcpConnectionDetails> GetActiveConnections();
        IEnumerable<TcpConnectionDetails> GetInActiveConnections();

        event TcpConnectionChangedEventHandler OnConnectionAdded;
        event TcpConnectionChangedEventHandler OnConnectionUpdated;
        event TcpConnectionChangedEventHandler OnConnectionRemoved;
    }
}
