using EasyModbus;
using System;
using System.Collections.Generic;
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
    }
}
