using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientWpfApp.Commands
{
	public class DiscreteSignalCheckboxCommand : ICommand
	{
		private RtuValueWriter rtuValueWriter;

		public event EventHandler CanExecuteChanged;
		public RTU SelectedRtu { get; set; }

		public DiscreteSignalCheckboxCommand(RtuValueWriter rtuValueWriter)
		{
			this.rtuValueWriter = rtuValueWriter;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			DiscreteSignalValue discreteSignalValue = (DiscreteSignalValue)parameter;

			if (MessageBox.Show("Da li želite da promenite vrednost signala " + discreteSignalValue.DiscreteSignal.Name
				 + " na vrednost" + (!discreteSignalValue.Value).ToString() , "Question", MessageBoxButton.YesNo, 
				 MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				rtuValueWriter.WriteDiscreteSignalValue(SelectedRtu.RTUData.ID, discreteSignalValue.DiscreteSignal.Address, !discreteSignalValue.Value);
				discreteSignalValue.Value = !discreteSignalValue.Value;
			}
			else
			{
				return;
			}


		}
	}
}
