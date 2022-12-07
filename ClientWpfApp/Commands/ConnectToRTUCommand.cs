using System;
using System.Windows.Input;
using ClientWpfApp.Model.RTU;
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
