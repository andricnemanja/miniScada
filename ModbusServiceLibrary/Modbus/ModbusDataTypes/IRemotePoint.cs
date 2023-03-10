namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IRemotePoint
	{
		int RtuId { get; }

		int Address { get; }
	}
}
