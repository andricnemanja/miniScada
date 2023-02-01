using NModbus;

namespace ModbusServiceLibrary.ModbusClient
{
	public class RtuConnection
	{
		public IModbusMaster modbusMaster { get; set; }
		public int RtuId { get; set; }
	}
}
