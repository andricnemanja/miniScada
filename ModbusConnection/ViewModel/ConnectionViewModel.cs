using ModbusConnection.Commands;
using ModbusConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModbusConnection.ViewModel
{
    internal class ConnectionViewModel
    {
        private RTU rtu;

        public ConnectToRTUCommand ConnectToRTUCommand { get; set; }

        private string _ipAddress;

        public string IpAddress
        {
            get { return _ipAddress; }
            set 
            { 
                _ipAddress = value;
                ConnectToRTUCommand.IpAddress = _ipAddress;
            }
        }


        private int _port;

        public int Port
        {
            get { return _port; }
            set 
            { 
                _port = value;
                ConnectToRTUCommand.Port = _port;
            }
        }



        public ConnectionViewModel(RTU rtu)
        {
            this.rtu = rtu;
            ConnectToRTUCommand = new ConnectToRTUCommand(rtu, IpAddress, Port);
        }
    }
}
