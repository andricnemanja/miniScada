using ClientWpfApp.View;
using ClientWpfApp.Model.RTU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientWpfApp.ServiceReader;

namespace ClientWpfApp.Commands
{
    public class ConnectToRtuCommand : ICommand
    {
        private RtuConnection rtuConnection;

        public event EventHandler CanExecuteChanged;

		public ConnectToRtuCommand(RtuConnection rtuConnection)
		{
			this.rtuConnection = rtuConnection;
		}

		public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RTU rtu = (RTU)parameter;
            rtu.IsConnected = rtuConnection.TryConnectToRtu(rtu.RTUData.ID);
		}
    }
}
