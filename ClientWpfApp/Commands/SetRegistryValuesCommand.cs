using System;
using System.Windows.Input;
using ClientWpfApp.View;

namespace ClientWpfApp.Commands
{
	internal class SetRegistryValuesCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			RegistryValuesWindow registryValuesWindow = new RegistryValuesWindow();
			registryValuesWindow.Show();
		}
	}
}
