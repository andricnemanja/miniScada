using System;
using System.Windows.Input;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public sealed class ReadRtuValuesCommand : ICommand
	{
		private readonly ModbusServiceWpfClient modbusServiceClient;

		public ReadRtuValuesCommand(ModbusServiceWpfClient modbusServiceClient)
		{
			this.modbusServiceClient = modbusServiceClient;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			modbusServiceClient.ReadValues();
		}
	}
}
