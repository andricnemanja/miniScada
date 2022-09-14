using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model.Signals
{
    internal class AnalogSignal : ISignal
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
            set { _value = value; }
        }

        public IModbusClient ModbusClient { get; set; }

        public AnalogSignal(int address, string? name, int value, IModbusClient modbusClient)
        {
            _address = address;
            _name = name;
            _value = value;
            ModbusClient = modbusClient;
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
