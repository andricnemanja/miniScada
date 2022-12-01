using ClientWpfApp.Model.RTU;
using ClientWpfApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
