using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection
{
    public interface IModbusClient
    {

        public void WriteSingleRegister(int startingAddress, int value);
        public int ReadSingleRegister(int startingAddress);
        public bool IsAvailable();
        public void Reconnect();
        public ushort[] ReadHoldingRegisters(int startingAddress, int numberOfRegisters);
        public ushort[] ReadAnalogInputs(int startingAddress, int numberOfRegisters);
        public bool[] ReadCoils(int startingAddress, int numberOfCoils);
        public bool[] ReadDiscreteInputs(int startingAddress, int numberOfCoils);
        public void Disconnect();
        void WriteSingleCoil(int coilAddress, bool value);
        void WriteMultipleCoil(int coilAddress, bool[] data);
    }
}
