using System;
using System.Windows.Input;
using ClientWpfApp.Services;

namespace ClientWpfApp.Commands
{
	public class ReadRtuValuesCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly RtuValuesReader rtuValuesReader;

		public ReadRtuValuesCommand(RtuValuesReader rtuValuesReader)
		{
			this.rtuValuesReader = rtuValuesReader;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			rtuValuesReader.ReadValues();
		}
	}
}
