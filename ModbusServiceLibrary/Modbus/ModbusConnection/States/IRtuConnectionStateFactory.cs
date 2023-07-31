using ModbusServiceLibrary.ModbusConnection;
using ModbusServiceLibrary.ModbusConnection.States;

namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	public interface IRtuConnectionStateFactory
	{
		IRtuConnectionState CreateConnection(RtuConnectionState rtuConnectionState, RtuConnection rtuConnection);
	}
}