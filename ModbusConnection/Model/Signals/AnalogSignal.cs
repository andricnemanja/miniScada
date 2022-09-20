using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model.Signals
{
    internal class AnalogSignal : ISignal, INotifyPropertyChanged
    {
        private int _address;

        public int Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _value;


        public int Value
        {
            get { return _value; }
            set 
            {
                if (value != _value)
                {
                    _value = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        public AnalogSignal(int address, string? name, int value)
        {
            _address = address;
            _name = name;
            _value = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
