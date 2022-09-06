using EasyModbus;
using EasyModbus.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection
{
    public class EasyModbusClient : IModbusClient
    {

        private ModbusClient modbusClient;

        public EasyModbusClient(string ipAddress, int port)
        {
            modbusClient = new ModbusClient(ipAddress, port);
            modbusClient.Connect();
        }

        public int ReadSingleRegister(int startingAddress)
        {
            return modbusClient.ReadHoldingRegisters(startingAddress, 1)[0];
        }

        public void WriteSingleRegister(int startingAddress, int value)
        {
            modbusClient.WriteSingleRegister(startingAddress, value);
        }

        public bool IsAvailable()
        {
            try
            {
                modbusClient.Connect();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Reconnect()
        {
            modbusClient.Connect();
        }

        public ushort[] ReadHoldingRegisters(int startingAddress, int numberOfRegisters)
        {
            throw new NotImplementedException();
        }

        public bool[] ReadCoils(int startingAddress, int numberOfCoils)
        {
            throw new NotImplementedException();
        }

        public bool[] ReadDiscreteInputs(int startingAddress, int numberOfCoils)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public ushort[] ReadAnalogInputs(int startingAddress, int numberOfRegisters)
        {
            throw new NotImplementedException();
        }

        public void WriteSingleCoil(int coilAddress, bool value)
        {
            throw new NotImplementedException();
        }

        public void WriteMultipleCoil(int coilAddress, bool[] data)
        {
            throw new NotImplementedException();
        }
    }
}
