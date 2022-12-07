using System;
using System.Windows.Input;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public class ReadRtuValuesCommand : ICommand
	{
		private readonly ModbusServiceClient modbusServiceClient;

		public ReadRtuValuesCommand(ModbusServiceClient modbusServiceClient)
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
