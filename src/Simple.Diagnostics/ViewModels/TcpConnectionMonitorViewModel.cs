using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Simple.Diagnostics
{
    internal class TcpConnectionMonitorViewModel : INotifyPropertyChanged
    {
        public TcpConnectionMonitorViewModel()
        {

        }

        public int ActiveConnections { get; set; }

        public int InActiveConnections { get; set; }

        public IList<TcpConnectionViewModel> ViewModels { get; } = new List<TcpConnectionViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
