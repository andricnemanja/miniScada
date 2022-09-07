﻿using ModbusConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModbusConnection.Commands
{
    internal class ConnectToRTUCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private RTU rtu;
        public string IpAddress { get; set; }
        public int Port { get; set; }

        public ConnectToRTUCommand(RTU rtu, string ipAddress, int port)
        {
            this.rtu = rtu;
            this.IpAddress = ipAddress;
            this.Port = port;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            IModbusClient modbusClient = new NModbusClient(IpAddress, Port);
            rtu.Connection.Client = modbusClient;
            rtu.Connection.Status = true;
        }
    }
}