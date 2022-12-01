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
	public class SavaAnalogSignalCommand : ICommand
	{
		private RtuValueWriter rtuValueWriter;

		public event EventHandler CanExecuteChanged;
		public RTU SelectedRtu { get; set; }

		public SavaAnalogSignalCommand(RtuValueWriter rtuValueWriter)
		{
			this.rtuValueWriter = rtuValueWriter;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AnalogSignalValue analogSignalValue = (AnalogSignalValue)parameter;

			if (MessageBox.Show("Da li želite da promenite vrednost signala " + analogSignalValue.AnalogSignal.Name
				 + " na vrednost " + (analogSignalValue.Value).ToString() , "Question", MessageBoxButton.YesNo, 
				 MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				rtuValueWriter.WriteAnalogSignalValue(SelectedRtu.RTUData.ID, analogSignalValue.AnalogSignal.Address, analogSignalValue.Value);
			}
			else
			{
				return;
			}


		}
	}
}
