using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Simple.Diagnostics
{
    internal class TcpMonitor : ITcpMonitor
    {
        static int connectionIndex;
        static int activeConnections;
        static int inActiveConnections;

        readonly static ConcurrentDictionary<string, TcpConnectionDetails> ActiveTcpConnections = new();
        readonly static ConcurrentDictionary<string, TcpConnectionDetails> InActiveTcpConnections = new();

        public TcpMonitor()
        {
            connectionIndex = 0;
            activeConnections = 0;
            inActiveConnections = 0;
        }

        public async Task Start(ILogger Logger, TimeSpan Interval)
        {
            while (true)
            {
                foreach (var item in GetTcpConnections())
                {
                    var Details = new TcpConnectionDetails(item)
                    {
                        Index = connectionIndex++
                    };

                    if (Details.State.Equals(TcpState.TimeWait))
                        RemoveConnection(Details);

                    else
                        AddOrUpdateConnection(Details);

                    Logger.LogInformation(Details.ToString());
                }
                await Task.Delay(Interval);

                LastUpdated = DateTimeOffset.UtcNow;
            }
        }

        public event TcpConnectionChangedEventHandler OnConnectionAdded;
        public event TcpConnectionChangedEventHandler OnConnectionUpdated;
        public event TcpConnectionChangedEventHandler OnConnectionRemoved;

        public int ActiveConnections { get => activeConnections; }
        public int InActiveConnections { get => inActiveConnections; }
        public DateTimeOffset LastUpdated { get; private set; }

        public IEnumerable<TcpConnectionDetails> GetActiveConnections()
        {
            return ActiveTcpConnections
                .Values
                .OrderByDescending(e => e.LastUpdated)
                .ToList();
        }
        public IEnumerable<TcpConnectionDetails> GetInActiveConnections()
        {
            return InActiveTcpConnections
                .Values
                .OrderByDescending(e => e.LastUpdated)
                .ToList();
        }

        void AddOrUpdateConnection(TcpConnectionDetails Details)
        {
            if (ActiveTcpConnections.TryAdd(Details.Id, Details))
            {
                activeConnections++;
                OnConnectionAdded?.Invoke(this, new TcpConnectionChangedEventArgs(Details));
            }
            else if (ActiveTcpConnections.TryUpdate(Details.Id, Details, Details))
                OnConnectionUpdated?.Invoke(this, new TcpConnectionChangedEventArgs(Details));
        }
        void RemoveConnection(TcpConnectionDetails Details)
        {
            if (ActiveTcpConnections.TryRemove(Details.Id, out var removedDetails))
            {
                activeConnections--;

                if (InActiveTcpConnections.TryAdd(Details.Id, Details))
                {
                    inActiveConnections++;
                    OnConnectionRemoved?.Invoke(this, new TcpConnectionChangedEventArgs(Details));
                }
            }
        }
        static IEnumerable<TcpConnectionInformation> GetTcpConnections()
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();

            foreach (var item in properties.GetActiveTcpConnections())
                yield return item;
        }
    }
}
