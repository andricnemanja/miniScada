using ModbusServiceLibrary.ModbusConnection;

namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusConnectionManager
	{
		RtuConnection GetRtuConnection(int rtuId);
	}
}