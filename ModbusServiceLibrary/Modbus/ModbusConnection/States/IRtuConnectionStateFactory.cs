namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	public interface IRtuConnectionStateFactory
	{
		IRtuConnectionState CreateConnection(RtuConnectionState rtuConnectionState, RtuConnection rtuConnection);
	}
}