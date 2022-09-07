﻿using ModbusConnection.Model;
using ModbusConnection.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModbusConnection.Commands
{
    internal class CreateConnectionWindowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            RTU rtu = (RTU)parameter;

            ConnectionWindow connectionWindow = new ConnectionWindow(rtu);
            connectionWindow.Show();
        }
    }
}