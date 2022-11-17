using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusClient
{
    public interface IModbusClient
    {

        void WriteSingleRegister(int startingAddress, int value);
        int ReadSingleRegister(int startingAddress);
        bool IsAvailable();
        void Reconnect();
        ushort[] ReadHoldingRegisters(int startingAddress, int numberOfRegisters);
        ushort[] ReadAnalogInputs(int startingAddress, int numberOfRegisters);
        bool[] ReadCoils(int startingAddress, int numberOfCoils);
        bool[] ReadDiscreteInputs(int startingAddress, int numberOfCoils);
        void Disconnect();
        void WriteSingleCoil(int coilAddress, bool value);
        void WriteMultipleCoil(int coilAddress, bool[] data);
    }
}
