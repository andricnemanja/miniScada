namespace ModbusServiceLibrary.Modbus.ModbusConnection
{
	public interface IRtuConnectionFactory
	{
		IRtuConnection GetRtuConnection();
	}
}
