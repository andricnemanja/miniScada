using ClientWpfApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
