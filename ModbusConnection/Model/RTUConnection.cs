namespace ModbusConnection.Model
{
    internal class RTUConnection
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