﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model.Signals
{
    internal class DiscreteSignal : ISignal, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _address;

        public int Address
        {
            get { return _address; }
            set 
            {
                if(_address != value)
                {
                    _address = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        private string? _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _value;


        public bool Value
        {
            get { return _value; }
            set 
            { 
                if(value != _value)
                {
                    _value = value;
                    RaisePropertyChanged("Value");
                    //Write();
                }
            }
        }


        public DiscreteSignal(int address, string? name, bool value)
        {
            _address = address;
            _name = name;
            _value = value;
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}