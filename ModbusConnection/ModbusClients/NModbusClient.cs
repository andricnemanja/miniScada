using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection
{
    public class NModbusClient : IModbusClient
    {
        private IModbusMaster master;
        private string ipAddress;
        private int port;

        public NModbusClient(string ipAddress, int port)
        {
            TcpClient client = new TcpClient(ipAddress, port);
            var factory = new ModbusFactory();
            master = factory.CreateMaster(client);

            this.ipAddress = ipAddress;
            this.port = port;
        }


        public int ReadSingleRegister(int startingAddress)
        {
            ushort[] value = master.ReadHoldingRegisters(1, (ushort)startingAddress, 1);
            return value[0];
        }

        public void WriteSingleRegister(int startingAddress, int value)
        {
            master.WriteSingleRegister(1, (ushort)startingAddress, (ushort)value);
        }

        public bool IsAvailable()
        {
            try
            {
                TcpClient client = new TcpClient(ipAddress, port);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Reconnect()
        {
            TcpClient client = new TcpClient(ipAddress, 502);
            var factory = new ModbusFactory();
            master = factory.CreateMaster(client);
        }
    }
}
