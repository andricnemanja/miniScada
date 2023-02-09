using System;
using System.Windows;
using System.Windows.Input;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Commands
{
	public sealed class ChangeDiscreteSignalFirstStateCommand : ICommand
	{
		private readonly ModbusServiceClient modbusServiceClient;

		public ChangeDiscreteSignalFirstStateCommand(ModbusServiceClient modbusServiceClient)
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
				+ " na " + discreteSignalValue.PossibleStates[0], "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				modbusServiceClient.WriteDiscreteSignalValue(SelectedRtu.RTUData.ID, discreteSignalValue.DiscreteSignal.ID, discreteSignalValue.PossibleStates[0]);
				discreteSignalValue.State = discreteSignalValue.PossibleStates[0];
			}
			else
			{
				return;
			}
		}
	}
}
