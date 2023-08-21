using System;
using System.Windows.Input;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public sealed class ConnectToRtuCommand : ICommand
	{
		private readonly RtuConnection rtuConnection;

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
			if (rtu.OffScan)
			{
				rtuConnection.RtuOnScan(rtu.RTUData.ID);
			}
			else
			{
				rtuConnection.RtuOffScan(rtu.RTUData.ID);
			}
		}
	}
}
