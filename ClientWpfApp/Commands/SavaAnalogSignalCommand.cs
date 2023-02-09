using System;
using System.Windows;
using System.Windows.Input;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public sealed class SavaAnalogSignalCommand : ICommand
	{
		private readonly ModbusServiceClient modbusServiceClient;

		public SavaAnalogSignalCommand(ModbusServiceClient modbusServiceClient)
		{
			this.modbusServiceClient = modbusServiceClient;
		}

		public event EventHandler CanExecuteChanged;
		public RTU SelectedRtu { get; set; }

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AnalogSignalValue analogSignalValue = (AnalogSignalValue)parameter;

			if (MessageBox.Show("Da li želite da promenite vrednost signala " + analogSignalValue.AnalogSignal.Name
				 + " na vrednost " + (analogSignalValue.Value).ToString(), "Question", MessageBoxButton.YesNo,
				 MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				modbusServiceClient.WriteAnalogSignalValue(SelectedRtu.RTUData.ID, analogSignalValue.AnalogSignal.ID, analogSignalValue.Value);
			}
			else
			{
				return;
			}
		}
	}
}
