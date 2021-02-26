using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Simple.Diagnostics
{
    internal class TcpConnectionDetails
    {
        public TcpConnectionDetails(TcpConnectionInformation Info)
        {
            this.State = Info.State;
            LastUpdated = DateTimeOffset.UtcNow;
            SetLocalEndPoint(Info.LocalEndPoint);
            SetRemoteEndPoint(Info.RemoteEndPoint);

            Id = $"{Info.LocalEndPoint.Port}:{Info.RemoteEndPoint.Port}";
        }
        public string Id { get; }
        public int Index { get; set; }
        public TcpState State { get; }
        public DateTimeOffset LastUpdated { get; }
        public int LocalPort { get; private set; }
        public int RemotePort { get; private set; }
        public IPEndPoint LocalEndpoint { get; private set; }
        public IPEndPoint RemoteEndpoint { get; private set; }

        void SetLocalEndPoint(IPEndPoint p)
        {
            LocalEndpoint = p;
            LocalPort = p.Port;
        }
        void SetRemoteEndPoint(IPEndPoint p)
        {
            RemoteEndpoint = p;
            RemotePort = p.Port;
        }

        public override string ToString()
        {
            return $"Local: {LocalEndpoint}\n\n" +
                $"Port: {LocalPort}\n\n" +
               $" <===========> " +
               $"Remote: {RemoteEndpoint}\n\n" +
               $"Port: {RemotePort}\n\n" +
               $" =========> " +
               $"State: {State}\n\n";
        }
    }
}
