using ModbusServiceLibrary.ModbusClient;
using System.ComponentModel;

namespace ModbusServiceLibrary.Model
{
    public class RTUConnection
    {
        public bool Status { get; set; }
        public IModbusClient Client { get; set; }

        public RTUConnection(IModbusClient client, bool status = false)
        {
            Status = status;
            Client = client;
        }
    }
}