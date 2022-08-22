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
    }
}
