using System;
using System.Threading.Tasks;
using System.Windows;
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

		public async void Execute(object parameter)
		{
			await Task.Run(() =>
			{
				RTU rtu = (RTU)parameter;
				if (rtuConnection.TryConnectToRtu(rtu.RTUData.ID).CommandStatus == ModbusServiceLibrary.CommandResult.CommandStatus.Executed)
					rtu.IsConnected = true;
				else
					MessageBox.Show("Ne moze se ostvariti veza sa " + rtu.RTUData.Name);
			});
		}
	}
}
