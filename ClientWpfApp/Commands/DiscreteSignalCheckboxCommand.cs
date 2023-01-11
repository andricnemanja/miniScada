using System;
using System.Windows;
using System.Windows.Input;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public sealed class DiscreteSignalCheckboxCommand : ICommand
	{
		private readonly ModbusServiceClient modbusServiceClient;

		public DiscreteSignalCheckboxCommand(ModbusServiceClient modbusServiceClient)
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
			DiscreteSignalValue discreteSignalValue = (DiscreteSignalValue)parameter;

			if (MessageBox.Show("Da li želite da promenite vrednost signala " + discreteSignalValue.DiscreteSignal.Name
				 + " na vrednost " + (discreteSignalValue.State).ToString(), "Question", MessageBoxButton.YesNo,
				 MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				modbusServiceClient.WriteDiscreteSignalValue(SelectedRtu.RTUData.ID, discreteSignalValue.DiscreteSignal.Address, discreteSignalValue.State);
			}
			else
			{
				return;
			}


		}
	}
}
