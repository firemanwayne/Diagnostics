using System;

namespace Simple.Diagnostics
{
    internal class TcpConnectionChangedEventArgs : EventArgs
    {
        public TcpConnectionDetails Details { get; }

        public TcpConnectionChangedEventArgs(TcpConnectionDetails Details)
        {
            this.Details = Details;
        }
    }
}
